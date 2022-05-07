export interface Restaurant {
	id: string
	name: string
	description: string
	image: string
	address: string
	timeWork: string
	categories: [Category]
	products: [Product]
	deliveryPrice: number
	minSum: number
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

export interface Account {
	id: string
	name: string
	email: string
	address: string
	entrance?: string
	intercom?: string
	floor?: number
	flat?: string
}
