export interface Restaurant {
    id: string,
    name: string,
    description: string,
    image: string,
    address: string,
    timeWork: string,
    categories: [Category];
    products: [Product],
    deliveryPrice: number,
    minSum: number
  }
  
  export interface Category {
    id: string,
    name: string
  }
  
  export interface Product {
    id: string,
    name: string,
    price: number,
    description: string,
    image: string
  }