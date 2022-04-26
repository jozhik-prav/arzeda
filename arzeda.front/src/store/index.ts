import { OrderLine } from '@/Types'
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
	state: {
		user: {
			name: '',
			email: '',
		},
		order: Array<OrderLine>(),
	},
	mutations: {
		login(state, user) {
			state.user = user
		},
		logout(state) {
			state.user = {
				name: '',
				email: '',
			}
		},
		addProduct(state, payload) {
			const orderLine = state.order.find(
				x => x.product.id === payload.product.id
			)
			if (orderLine) orderLine.count++
			else
				state.order.push({
					product: payload.product,
					count: payload.count,
				})
		},
		incrementCountProduct(_, orderLine) {
			orderLine.count++
		},
		decrementCountProduct(_, orderLine) {
			orderLine.count--
		},
		deleteOrderLine(state, index) {
			state.order.splice(index, 1)
		},
	},
	actions: {
		incrementCountProduct({ commit, state, getters }, id) {
			const index = getters.findOrdelLineByIndex(id)
			if (index >= 0) commit('incrementCountProduct', state.order[index])
			else console.error('Этого товара нет в корзине')
		},
		decrementCountProduct({ commit, state, getters }, id) {
			const index = getters.findOrdelLineByIndex(id)
			if (index >= 0) {
				const orderLine = state.order[index]
				if (orderLine.count == 1) commit('deleteOrderLine', index)
				else commit('decrementCountProduct', orderLine)
			}
		},
		deleteOrderLine({ commit, state, getters }, id) {
			const index = getters.findOrdelLineByIndex(id)
			if (index >= 0) commit('deleteOrderLine', index)
		},
	},
	getters: {
		isLogin: (state): boolean => {
			return state.user.email != ''
		},
		totalSum: (state, getters): number => {
			return state.order
				.map(x => x.product.price * x.count)
				.reduce((a, b) => a + b, 0)
		},
		positionCount: (state): number => {
			return state.order.length
		},
		orderIsEmpty: (_, getters): boolean => {
			return getters.positionCount === 0
		},
		findOrdelLineByIndex: state => (id: string): number => {
			return state.order.findIndex(x => x.product.id === id)
		},
	},
	modules: {},
})
