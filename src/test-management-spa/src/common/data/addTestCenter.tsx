import { useState, useCallback } from 'react';
import { apiClient } from '../../util/axios';
import { AdminForm } from '../../pages/admin/useAdmin';

const url = '/TestCenter';

interface IAddTestCenter {
	saving: boolean;
	id: string | null;
	saveTestCenter: (destination: AdminForm) => Promise<void>;
}

export const useAddTestCenter = (): IAddTestCenter => {
	const [saving, setSaving] = useState<boolean>(false);
	const [id, setId] = useState<string>('');
	const saveTestCenter = useCallback(async data => {
		setSaving(true);
		console.log('---this method will be called');
		const resp = await apiClient.post<string>(url, data).catch((error: any) => {
			setSaving(false);
			setId('');
			console.log(error);
		});

		if (resp && resp?.data) {
			setId(resp.data);
			setSaving(false);
		}
	}, []);
	return { saving, id, saveTestCenter };
};
