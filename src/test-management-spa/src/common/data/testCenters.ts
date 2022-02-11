import { useCallback, useEffect, useState } from 'react';
import { ITestCenters } from '../types';
import { apiClient } from '../../util/axios';


export interface ITestCenterHookReturn {
	loading: boolean;
	data: ITestCenters[] | null;
	fetchTestCenters: () => Promise<void>;
}
const url = '/v1/TestCenter';

export const useTestCenter = (): ITestCenterHookReturn => {
	const [loading, setLoading] = useState<boolean>(false);
	const [data, setData] = useState<ITestCenters[] | null>(null);
	const fetchTestCenters = useCallback(async () => {
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
		fetchTestCenters();

		// fetchDefect();
	}, []);

	return { loading, data, fetchTestCenters };
};
