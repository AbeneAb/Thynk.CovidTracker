import * as yup from 'yup';
import {
	DeepMap,
	FieldError,
	useForm,
	UseFormHandleSubmit,
	UseFormRegister,
	UseFormWatch,
} from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { apiClient } from '../../util/axios';

export interface BookingForm {
	testCenter?: string;
	bookingDate?: number;
	bookingStatus?: number;
}

const schema = yup.object().shape({
	testCenter: yup.string().required(),
	bookingDate: yup.date().required(),
	bookingStatus: yup.string().required(),
});

export interface BookingFormReturnType {
	classNames: (...classes: string[]) => string;
	register: UseFormRegister<BookingForm>;
	handleSubmit: UseFormHandleSubmit<BookingForm>;
	watch: UseFormWatch<BookingForm>;
	errors: DeepMap<BookingForm, FieldError>;
	isSubmitting: boolean;


	onValidSubmitHandler: (data: BookingForm) => void;
	onInvalidSubmitHandler: (errors: DeepMap<BookingForm, FieldError>) => void;
}



export const useBookingForm = (): BookingFormReturnType => {
	const classNames = (...classes: string[]) =>
		classes.filter(Boolean).join(' ');
	const {
		register,
		handleSubmit,
		watch,
		formState: { errors, isSubmitting },
	} = useForm<BookingForm>({ resolver: yupResolver(schema) });
	const onValidSubmitHandler = async (data: BookingForm) => {
		console.log(data);
		const resp = await apiClient
			.post<string>('/v1/Booking/create', data)
			.catch((error: any) => {
				console.log(error);
			});

		if (resp && resp?.data) {
			console.log(resp.data);
		}
	};
	const onInvalidSubmitHandler = (err: DeepMap<BookingForm, FieldError>) => {
		console.log(err);
	};
	return {
		classNames,
		register,
		handleSubmit,
		watch,
		errors,
		isSubmitting,
		onValidSubmitHandler,
		onInvalidSubmitHandler,
	};
};
