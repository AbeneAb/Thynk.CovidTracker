/* eslint-disable jsx-a11y/label-has-associated-control */
import React from 'react';
import { Table } from 'antd';
import { useLabForm } from './useLab';
import { useBookingWithSpecimenList } from '../../common/data/result';

const Lab: React.FunctionComponent = () => {
	const { data: bookingList } = useBookingWithSpecimenList();
    const columns = [
		{ title: 'Test Center', dataIndex: 'testCenter', key: 'testCenter' },
		{ title: 'First Name', dataIndex: 'firstName', key: 'firstName' },
		{ title: 'Last Name', dataIndex: 'lastName', key: 'lastName' },
		{ title: 'Booking Date', dataIndex: 'bookingDate', key: 'bookingDate' },
		{ title: 'Booking Status', dataIndex: 'bookingDate', key: 'bookingDate' },
	];
	const {
		register,
		handleSubmit,
		onValidSubmitHandler,
		onInvalidSubmitHandler,
	} = useLabForm();
	return (
		<div className="w-full min-h-screen mb-10">
			<form
				onSubmit={handleSubmit(onValidSubmitHandler, onInvalidSubmitHandler)}>
				<div className="py-2 mx-8 mt-12 space-y-8 lg:mx-32 width-full ">
					{/* Page heading */}
					<div className="mx-auto space-y-2">
						<h2 className="text-2xl font-medium leading-6 text-gray-900">
							Fill Result for a booking with specimen
						</h2>
						<p className="max-w-4xl text-sm text-gray-500">
							Hi There {' '}
							<span className="font-bold text-indigo-500">Lab Technician</span> We salute you for doing your job.
						</p>
					</div>
					{/* First Part */}
					<div>
						<div className="md:grid md:grid-cols-3 md-gap-6">
							<div className="px-4 md:col-span-1 sm:px-1">
								<h3 className="text-lg font-medium leading-6 text-gray-900">
									Specimen Collection for booking
								</h3>
								<p className="mt-1 text-sm text-gray-600">
									Pick the booking for which we will fill in Result Information
								</p>
							</div>
							<div className="mt-5 md:mt-0 md:col-span-2">
								<div className="px-4 py-5 space-y-6 bg-white shadow sm:rounded-md sm:overflow-hidden sm:p-6">
									<div className="col-span-3 sm:col-span-2">
										{/* Test -Center-input */}
										<div>
											<label
												htmlFor="testCenter"
												className="block text-sm font-medium text-gray-700">
												Booking Information
											</label>
											<div className="relative mt-1 rounded-md shadow-sm">
												<select
													defaultValue="Select Booking Id"
													{...register('id')}
													className="w-full h-full px-3 py-2 text-gray-500 bg-transparent bg-white border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm disabled:bg-gray-100">
													{bookingList?.map(c => (
														<option key={c.resultId} value={c.resultId}>
															{c.testCenter} {' '} {c.firstName} {' '} {c.bookingDate}
														</option>
													))}
												</select>
												<div className="absolute inset-y-0 right-0 flex items-center">
													<label htmlFor="re" className="sr-only">
														Booking Status
													</label>
													<select
														id="result"
														{...register('result')}
														className="h-full py-0 pl-2 text-gray-500 bg-transparent border-transparent rounded-md focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 pr-7 sm:text-sm">
														<option key={2} value={2}>
                                                        Negative
														</option>
														<option key={3} value={3}>
                                                        Positive
														</option>
														<option key={4} value={4}>
                                                        Inconclusive
														</option>
													</select>
												</div>
											</div>
										</div>
										{/* Booking Date */}
										<div>
											<label
												htmlFor="collectionDate"
												className="block text-sm font-medium text-gray-700">
												Specimen Collection Date
											</label>
											<div className="mt-1 rounded-md shadow-sm">
												<input
													type="text"
													className="flex-1 block w-full px-3 py-2 border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
													placeholder="02/11/2022"
													{...register('collectionDate', { valueAsDate: true })}
												/>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div>
						<div className="md:grid mg:grid-cols-1 md-gap-6 justify-items-end">
							<div className="items-center justify-center flex-1 w-full md:col-end-4 md:col-span-1">
								<button
									type="submit"
									className="items-center justify-center w-full px-6 py-3 text-sm font-medium text-white bg-yellow-400 border border-transparent rounded-md shadow-sm sm:text-base sm:inline-flex hover:bg-yellow-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-yellow-600">
									Update Result
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
							<div className="border-t border-gray-200" />
						</div>
					</div>
                    {/* Booking List */}
                    <div>
						<Table columns={columns} dataSource={bookingList!}/>
					</div>
				</div>
			</form>
		</div>
	);
};
export default Lab;
