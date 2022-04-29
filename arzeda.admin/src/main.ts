import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import axios, { AxiosStatic } from 'axios'

Vue.config.productionTip = false

Vue.prototype.$axios = axios
declare module 'vue/types/vue' {
	interface Vue {
		$axios: AxiosStatic
	}
}

new Vue({
	router,
	store,
	vuetify,
	render: (h) => h(App),
}).$mount('#app')
