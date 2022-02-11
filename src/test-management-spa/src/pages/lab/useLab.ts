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

export interface LabForm {
	id?: string;
	result?: number;
    collectionDate?: string;
}

const schema = yup.object().shape({
	id: yup.string().required(),
	result: yup.number().required(),
});

export interface LabFormReturnType {
	classNames: (...classes: string[]) => string;
	register: UseFormRegister<LabForm>;
	handleSubmit: UseFormHandleSubmit<LabForm>;
	watch: UseFormWatch<LabForm>;
	errors: DeepMap<LabForm, FieldError>;
	isSubmitting: boolean;
	onValidSubmitHandler: (data: LabForm) => void;
	onInvalidSubmitHandler: (errors: DeepMap<LabForm, FieldError>) => void;
}



export const useLabForm = (): LabFormReturnType => {
	const classNames = (...classes: string[]) =>
		classes.filter(Boolean).join(' ');
	const {
		register,
		handleSubmit,
		watch,
		formState: { errors, isSubmitting },
	} = useForm<LabForm>({ resolver: yupResolver(schema) });
	const onValidSubmitHandler = async (data: LabForm) => {
		console.log(data);
		const resp = await apiClient
			.put<string>('/v1/Result/update', data)
			.catch((error: any) => {
				console.log(error);
			});

		if (resp && resp?.data) {
			console.log(resp.data);
		}
	};
	const onInvalidSubmitHandler = (err: DeepMap<LabForm, FieldError>) => {
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
