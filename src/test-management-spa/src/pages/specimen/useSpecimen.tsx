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

export interface SpecimenInformationForm {
	bookingId?: string;
	collectionDate?: number;
	specimenTypeId?: number;
}

const schema = yup.object().shape({
	bookingId: yup.string().required(),
	collectionDate: yup.date().required(),
	specimenTypeId: yup.string().required(),
});

export interface SpecimenInformationFormReturnType {
	classNames: (...classes: string[]) => string;
	register: UseFormRegister<SpecimenInformationForm>;
	handleSubmit: UseFormHandleSubmit<SpecimenInformationForm>;
	watch: UseFormWatch<SpecimenInformationForm>;
	errors: DeepMap<SpecimenInformationForm, FieldError>;
	isSubmitting: boolean;
	onValidSubmitHandler: (data: SpecimenInformationForm) => void;
	onInvalidSubmitHandler: (errors: DeepMap<SpecimenInformationForm, FieldError>) => void;
}



export const useSpecimenInformationForm = (): SpecimenInformationFormReturnType => {
	const classNames = (...classes: string[]) =>
		classes.filter(Boolean).join(' ');
	const {
		register,
		handleSubmit,
		watch,
		formState: { errors, isSubmitting },
	} = useForm<SpecimenInformationForm>({ resolver: yupResolver(schema) });
	const onValidSubmitHandler = async (data: SpecimenInformationForm) => {
		console.log(data);
		const resp = await apiClient
			.post<string>('/v1/SpecimenInformation/create', data)
			.catch((error: any) => {
				console.log(error);
			});

		if (resp && resp?.data) {
			console.log(resp.data);
		}
	};
	const onInvalidSubmitHandler = (err: DeepMap<SpecimenInformationForm, FieldError>) => {
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
