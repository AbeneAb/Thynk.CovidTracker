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

export interface AdminForm {
	name?: string;
	capacity?: number;
	availableFrom?: number;
	availableUntil?: number;
	isAvailable?: boolean;
	city?: string;
	state?: string;
	street?: string;
	zipCode?: string;
	availableSpace?: number;
}

const schema = yup.object().shape({
	name: yup.string().max(400).required(),
	capacity: yup.number().min(0).required(),
	availableFrom: yup.date().min(0).required(),
	isAvailable: yup.bool().required(),
	city: yup.string().required(),
	state: yup.string().required(),
	street: yup.string().required(),
	zipCode: yup.string().required(),
	availableSpace: yup.number().required().min(0).max(yup.ref('Capacity')),
});
export interface TestCenterFormReturnType {
	classNames: (...classes: string[]) => string;
	register: UseFormRegister<AdminForm>;
	handleSubmit: UseFormHandleSubmit<AdminForm>;
	watch: UseFormWatch<AdminForm>;
	errors: DeepMap<AdminForm, FieldError>;
	isSubmitting: boolean;
	onValidSubmitHandler: (data: AdminForm) => void;
	onInvalidSubmitHandler: (errors: DeepMap<AdminForm, FieldError>) => void;
}

export const useAdminForm = (): TestCenterFormReturnType => {
	const classNames = (...classes: string[]) =>
		classes.filter(Boolean).join(' ');
	const {
		register,
		handleSubmit,
		watch,
		formState: { errors, isSubmitting },
	} = useForm<AdminForm>({ resolver: yupResolver(schema) });

	const onValidSubmitHandler = (data: AdminForm) => {
		console.log(data);
		const params = new URLSearchParams();
	};
	const onInvalidSubmitHandler = (err: DeepMap<AdminForm, FieldError>) => {
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
