export interface ITestCenters {
	id: string;
	name: string;
	capacity: number;
	isAvailable: boolean;
	availableFrom: string;
	availableUnitl: string;
	availableSpace: string;
	city: string;
	state: string;
	street: string;
	zipCode?: string;
}
export interface IBooking{
    id: string;
    testCenter:string;
    bookingDate: string;
    firstName: string;
    lastName:string;
    bookingStatus:string;
}
