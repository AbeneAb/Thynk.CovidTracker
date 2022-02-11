/* eslint-disable jsx-a11y/label-has-associated-control */
import React from 'react';
import { Table } from 'antd';
import 'antd/dist/antd.min.css';
import { useAdminForm } from './useAdmin';
import { useTestCenter } from '../../common/data/testCenters';

const AdminDashboard: React.FunctionComponent = () => {
	const { data } = useTestCenter();
	const columns = [
		{ title: 'Name', dataIndex: 'name', key: 'name' },
		{ title: 'City', dataIndex: 'city', key: 'city' },
		{ title: 'Capacity', dataIndex: 'capacity', key: 'capacity' },
		{ title: 'Available Space', dataIndex: 'availableSpace', key: 'availableSpace' },
		{ title: 'Available From', dataIndex: 'availableFrom', key: 'availableFrom' },
		{ title: 'Available Unitl', dataIndex: 'availableUnitl', key: 'availableUnitl' },
		{ title: 'State', dataIndex: 'state', key: 'state' },
		{ title: 'Street', dataIndex: 'street', key: 'street' },
		{ title: 'Zip Code', dataIndex: 'zipCode', key: 'zipCode' },

	];
	const {
		register,
		handleSubmit,
		onValidSubmitHandler,
		onInvalidSubmitHandler,
	} = useAdminForm();
	return (
		<div className="w-full min-h-screen mb-10">
			<form
				onSubmit={handleSubmit(onValidSubmitHandler, onInvalidSubmitHandler)}>
				<div className="py-2 mx-8 mt-12 space-y-8 lg:mx-32 width-full ">
					{/* Page heading */}
					<div className="mx-auto space-y-2">
						<h2 className="text-2xl font-medium leading-6 text-gray-900">
							Add Test centers
						</h2>
						<p className="max-w-4xl text-sm text-gray-500">
							Covid test{' '}
							<span className="font-bold text-indigo-500">cannot</span> ship
							personal goods or certain hazardous materials. If you are not
							feeling well free to check.
						</p>
					</div>
					{/* First part */}
					<div>
						<div className="px-4 py-5 col-span-3 space-y-6 bg-white shadow sm:rounded-md sm:overflow-hidden sm:p-6">
							<div className="md:grid md:grid-cols-3 md-gap-6">
								<div className="mt-5 md:mt-0 md:col-span-1">
									<div className="px-4 md:col-span-1 sm:px-1">
										{/* Name */}
										<div>
											<label
												htmlFor="name"
												className="block text-sm font-medium text-gray-700">
												Name
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="Test center name"
													{...register('name')}
												/>
											</div>
										</div>
										{/* Capacity */}
										<div>
											<label
												htmlFor="capacity"
												className="block text-sm font-medium text-gray-700">
												Capacity
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="0"
													{...register('capacity', { valueAsNumber: true })}
												/>
											</div>
										</div>
										<div>
											<label
												htmlFor="availableFrom"
												className="block text-sm font-medium text-gray-700">
												Available From
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="02/11/2022"
													{...register('availableFrom', { valueAsDate: true })}
												/>
											</div>
										</div>
										<div>
											<label
												htmlFor="availableUntil"
												className="block text-sm font-medium text-gray-700">
												Available Until
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="02/12/2022"
													{...register('availableUntil', { valueAsDate: true })}
												/>
											</div>
										</div>
									</div>
								</div>
								<div className="mt-5 md:mt-0 md:col-span-1">
									<div className="px-4 md:col-span-1 sm:px-1">
										{/* Name */}
										<div>
											<label
												htmlFor="city"
												className="block text-sm font-medium text-gray-700">
												City
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="City"
													{...register('city')}
												/>
											</div>
										</div>
										{/* Street */}
										<div>
											<label
												htmlFor="street"
												className="block text-sm font-medium text-gray-700">
												Street
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="Street"
													{...register('street')}
												/>
											</div>
										</div>
										{/* zipCode */}
										<div>
											<label
												htmlFor="zipCode"
												className="block text-sm font-medium text-gray-700">
												Zip Code
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="Zip code"
													{...register('zipCode')}
												/>
											</div>
										</div>
									</div>
								</div>
								<div className="mt-5 md:mt-0 md:col-span-1">
									<div className="px-4 md:col-span-1 sm:px-1">
										{/* State */}
										<div>
											<label
												htmlFor="state"
												className="block text-sm font-medium text-gray-700">
												State
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="State"
													{...register('state')}
												/>
											</div>
										</div>
										{/* availableSpace */}
										<div>
											<label
												htmlFor="availableSpace"
												className="block text-sm font-medium text-gray-700">
												Available Space
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="0"
													{...register('availableSpace', {
														valueAsNumber: true,
													})}
												/>
											</div>
										</div>
										{/* isAvailable */}
										<div>
											<label
												htmlFor="isAvailable"
												className="block text-sm font-medium text-gray-700">
												Is Available
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="checkbox"
													className="flex-1 block w-full px-3 py-4 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="0.00"
													{...register('isAvailable')}
												/>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					{/* Get Submitt Button */}
					<div>
						<div className="md:grid mg:grid-cols-1 md-gap-6 justify-items-end">
							<div className="items-center justify-center flex-1 w-full md:col-end-4 md:col-span-1">
								<button
									type="submit"
									className="items-center justify-center w-full px-6 py-3 text-sm font-medium text-white bg-yellow-400 border border-transparent rounded-md shadow-sm sm:text-base sm:inline-flex hover:bg-yellow-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-yellow-600">
									Save Test Center
									<div
										className={`hidden {isSubmitting ? 'inline-flex'} flex items-center justify-center `}>
										<div className="w-4 h-4 ml-10 border-b-2 rounded-full border-gray-50 animate-spin" />
									</div>
								</button>
							</div>
						</div>
					</div>
					{/* divider */}
					<div className="hidden sm:block" aria-hidden="true">
						<div className="py-5">
							<div className="border-t border-gray-200" />{' '}
						</div>
					</div>
					{/* Section-2 Test Center List and Delivery */}
					<div>
						<Table columns={columns} dataSource={data!}/>
					</div>
				</div>
			</form>
		</div>
	);
};
export default AdminDashboard;
