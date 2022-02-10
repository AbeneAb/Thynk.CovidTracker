import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';

// import { useAuthStore } from '../store/auth-store';

const requestHandler = (request: AxiosRequestConfig) => request;
const responseHandler = (response: AxiosResponse) => response;
const requestErrorHandler = (error: any) => Promise.reject(error);
const responseErrorHandler = (error: any) => Promise.reject(error);

export const apiClient = axios.create({
	baseURL: process.env.REACT_APP_API_ENDPOINT,
	headers: {
		'Access-Control-Allow-Origin': '*',
		'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, PUT',
		'Access-Control-Allow-Headers': '*',
		'Content-Type': 'application/json',
	},
});
apiClient.interceptors.request.use(
	request => requestHandler(request),
	error => requestErrorHandler(error),
);

apiClient.interceptors.response.use(
	response => responseHandler(response),
	error => responseErrorHandler(error),
);
export const errorHandler = (reason: any) => {
	if (axios.isCancel(reason)) return 'Request Cancelled';
	if (reason.code === 'ECONNABORTED') return 'A timeout occurred';
	if (reason.response?.status === 404) return 'Resource Not Found';
	if (reason.response?.status === 400 || reason.response?.status === 500)
		return reason.response.data.error_message;

	return 'An unexpected error has occured';
};
