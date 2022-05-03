export interface RestaurantApiModel {
	id: string
	name: string
	description: string
	image: string
	address: string
	timeWorkStart: string
	timeWorkEnd: string
	categories: string[]
	products: Product[]
	deliveryPrice: number
	minSum: number
}

export interface Restaurant {
	id: string
	name: string
	description: string
	image: string
	address: string
	timeWorkStart: string
	timeWorkEnd: string
	categories: string[]
	products: Product[]
	deliveryPrice: number
	minSum: number
}

export function RestaurantToModel(apiModel: RestaurantApiModel): Restaurant {
	const hoursStart = new Date(apiModel.timeWorkStart).getHours()
	const minutesStart = new Date(apiModel.timeWorkStart).getMinutes()
	const hoursEnd = new Date(apiModel.timeWorkEnd).getHours()
	const minutesEnd = new Date(apiModel.timeWorkEnd).getMinutes()
	return {
		id: apiModel.id,
		name: apiModel.name,
		description: apiModel.description,
		image: apiModel.image,
		address: apiModel.address,
		timeWorkStart: `${hoursStart}:${minutesStart}`,
		timeWorkEnd: `${hoursEnd}:${minutesEnd}`,
		categories: apiModel.categories,
		products: apiModel.products,
		deliveryPrice: apiModel.deliveryPrice,
		minSum: apiModel.minSum,
	}
}

export function RestaurantToApiModel(model: Restaurant): RestaurantApiModel {
	const [hoursStart, minutesStart] = model.timeWorkStart.split(':')
	const timeWorkStart = new Date(
		1995,
		10,
		2,
		+hoursStart,
		+minutesStart
	).toISOString()
	const [hoursEnd, minutesEnd] = model.timeWorkEnd.split(':')
	const timeWorkEnd = new Date(
		1995,
		10,
		2,
		+hoursEnd,
		+minutesEnd
	).toISOString()
	return {
		id: model.id,
		name: model.name,
		description: model.description,
		image: model.image,
		address: model.address,
		timeWorkStart: timeWorkStart,
		timeWorkEnd: timeWorkEnd,
		categories: model.categories,
		products: model.products,
		deliveryPrice: model.deliveryPrice,
		minSum: model.minSum,
	}
}

export interface Category {
	id: string
	name: string
}

export interface Product {
	id: string
	name: string
	price: number
	description: string
	image: string
	restaurantId: string
}

export interface OrderLine {
	product: Product
	count: number
}

export type SelectItem<T> = {
	text: string
	value: T
	disabled?: boolean
	divider?: boolean
	header?: string
}
