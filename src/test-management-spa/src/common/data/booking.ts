import { useCallback, useEffect, useState } from 'react';
import { IBooking } from '../types';
import { apiClient } from '../../util/axios';

export interface ITestCenterHookReturn {
	loading: boolean;
	data: IBooking[] | null;
	fetchBooking: () => Promise<void>;
}
const url = '/v1/Booking';

export const useBookingList = (): ITestCenterHookReturn => {
	const [loading, setLoading] = useState<boolean>(false);
	const [data, setData] = useState<IBooking[] | null>(null);
	const fetchBooking = useCallback(async () => {
		setLoading(true);
		const resp = await apiClient.get(url).catch((reason: any) => {
			console.log(reason);
			setData(null);
			setLoading(false);
		});

		if (resp && resp?.data) {
			setData(resp.data);
			setLoading(false);
		}
	}, []);
	useEffect(() => {
		fetchBooking();

		// fetchDefect();
	}, []);

	return { loading, data, fetchBooking };
};
