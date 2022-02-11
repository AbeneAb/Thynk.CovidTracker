import { useCallback, useEffect, useState } from 'react';
import { ITestBookingReport } from '../types';
import { apiClient } from '../../util/axios';

export interface ITestCenterResultReturn {
	loading: boolean;
	data: ITestBookingReport[] | null;
	fetchTestBookingReport: () => Promise<void>;
}
const url = '/v1/TestCenter/report';

export const useTestCenterResult = (): ITestCenterResultReturn => {
	const [loading, setLoading] = useState<boolean>(false);
	const [data, setData] = useState<ITestBookingReport[] | null>(null);

	const fetchTestBookingReport = useCallback(async () => {
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
		fetchTestBookingReport();
	}, []);
	return { loading, data, fetchTestBookingReport };
};
