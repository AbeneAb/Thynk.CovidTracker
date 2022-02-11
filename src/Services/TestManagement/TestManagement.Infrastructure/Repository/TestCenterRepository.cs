namespace TestManagement.Infrastructure.Repository
{
    public class TestCenterRepository : AsyncRepository<TestCenter>, ITestCenterRepository
    {
        private readonly ThynkContext _context;
        public TestCenterRepository(ThynkContext thynkContext) : base(thynkContext)
        {
            _context = thynkContext;
        }

        public async Task<IEnumerable<TestCenter>> GetAllTestCentersAsync()
        {
            var data = _context.Tests.Include(t=>t.Address)
                .Include(t=>t.TestCenterAvailableCapacity).AsNoTracking().ToListAsync();
            return await data;
        }

        public async Task<IEnumerable<TestCenter>> GetAvailabletestCenters(bool available)
        {
            var data = _context.Tests.Include(t => t.Address)
               .Include(t => t.TestCenterAvailableCapacity)
               .Where(x => x.IsAvailable == available
               && x.AvailableUntil > DateTime.Now
               && x.TestCenterAvailableCapacity.AvailableSpace > 0)
               .AsNoTracking().ToListAsync();
            return await data;
        }

        public async Task<IEnumerable<Domain.QueryModel.TestCenterBookingReport>> GetTestCenterReport()
        {
            var data = _context.TestCenterBookingReports.FromSqlRaw(@"select d.Id,d.Name, d.TotalBooking,d.Capacity, p.TotalPending,neg.TotalNegative,pos.TotalPositive
from(select tc.Id, tc.Name, tc.Capacity, count(b.Id) as TotalBooking from covid.TestCenter as tc inner join covid.Booking as b
on tc.Id = b.TestCenterId group by tc.Id, tc.Name, tc.Capacity)  d
left join
(select TotalPending, Id from(select tc.Id, tc.Name, count(r.Id) as TotalPending from covid.TestCenter as tc
inner join covid.Booking as b on tc.Id = b.TestCenterId
inner join covid.Result as r on b.Id = r.BookingId
inner join enum.ResultStatus as rs on r.ResultStatusId = rs.Id
where rs.Id = 1
group by tc.Id, tc.Name ,r.ResultStatusId) as pend)  p on d.Id = p.Id

left join(
select tc.Id, tc.Name, count(r.Id) as TotalNegative from covid.TestCenter as tc
inner join covid.Booking as b on tc.Id = b.TestCenterId
inner join covid.Result as r on b.Id = r.BookingId
inner join enum.ResultStatus as rs on r.ResultStatusId = rs.Id
where rs.Id = 2
group by tc.Id, tc.Name ,r.ResultStatusId,rs.Name) as neg on d.Id = neg.Id

left join(
select tc.Id, count(r.Id) as TotalPositive from covid.TestCenter as tc
inner join covid.Booking as b on tc.Id = b.TestCenterId
inner join covid.Result as r on b.Id = r.BookingId
inner join enum.ResultStatus as rs on r.ResultStatusId = rs.Id
where rs.Id = 3
group by tc.Id, tc.Name ,r.ResultStatusId,rs.Name) as pos on pos.Id = d.Id

").ToListAsync();
            return await data;
        }
    }
}
