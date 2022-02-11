import React from 'react';
import { Table } from 'antd';
import { useTestCenterResult } from '../../common/data/allResult';

const ReportViewer: React.FunctionComponent = () => {
	const { data: testCenterResult } = useTestCenterResult();
	const columns = [
		{ title: 'Test Center', dataIndex: 'name', key: 'testCenter' },
		{ title: 'Capacity', dataIndex: 'capacity', key: 'capacity' },
		{ title: 'Total Booking', dataIndex: 'totalBooking', key: 'totalBooking' },
		{ title: 'Positives', dataIndex: 'totalPositive', key: 'positives' },
		{ title: 'Negatives', dataIndex: 'totalNegative', key: 'negatives' },
        { title: 'Pending', dataIndex: 'totalPending', key: 'inconclusive' },

	];

	return (
		<div className="w-full min-h-screen mb-10">
			<div className="py-2 mx-8 mt-12 space-y-8 lg:mx-32 width-full">
				<Table columns={columns} dataSource={testCenterResult!} />
			</div>
		</div>
	);
};
export default ReportViewer;
