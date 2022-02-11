import axios, {  CancelTokenSource } from 'axios';
import { useEffect, useState, useRef } from 'react';
import { ITestCenters } from '../types';
import { apiClient } from '../../util/axios';

export interface IAvailableTestCenterHookReturn {
	loading: boolean;
	data: ITestCenters[] | null;
	fetchTestCenters: () => void;
}
const url = '/v1/TestCenter/getavailable?isAvalable=true';
interface TAvailableTestCenterProps {
	immediate: boolean;
}

export const useAvailableTestCenter = (
	props: TAvailableTestCenterProps,
): IAvailableTestCenterHookReturn => {
	const cancelSource = useRef<CancelTokenSource | null>(null);

	const { immediate } = props;
	const [loading, setLoading] = useState<boolean>(false);
	const [data, setData] = useState<ITestCenters[] | null>(null);
	const fetchTestCenters = async () => {
		setLoading(true);
		const resp = await apiClient.get(url,{
            cancelToken: cancelSource?.current?.token,
        }).catch((reason: any) => {
			console.log(reason);
			setData(null);
			setLoading(false);
		});

		if (resp && resp?.data) {
			setData(resp.data);
			setLoading(false);
		}
	};
	useEffect(() => {
		cancelSource.current = axios.CancelToken.source();

		if (immediate) {
			fetchTestCenters();
		}
		return () => {
			cancelSource?.current?.cancel();
		};
	}, [immediate]);

	return { loading, data, fetchTestCenters };
};
