import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
	state: {
		user: {
			name: '',
			email: '',
		},
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
	},
	actions: {},
	getters: {
		isLogin: (state): boolean => {
			return state.user.email != ''
		},
	},
	modules: {},
})
