import store from '@/store'
import axios from 'axios'
import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Restaurant from '../views/Restaurant.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
	{
		path: '/',
		name: 'Restaurant',
		component: Restaurant,
		meta: {
			requiresAuth: true,
		},
	},
	{
		path: '/login',
		name: 'Login',
		component: () => import('../views/Login.vue'),
	},
	{
		path: '/restaurant',
		name: 'Restaurant',
		component: () => import('../views/Restaurant.vue'),
		meta: {
			requiresAuth: true,
		},
	},
	{
		path: '/products',
		name: 'Products',
		component: () => import('../views/Products.vue'),
		meta: {
			requiresAuth: true,
		},
	},
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
})

router.beforeEach((to, from, next) => {
	if (to.matched.some((record) => record.meta.requiresAuth)) {
		if (!store.getters.isLogin) {
			axios
				.get('/api/account/userInfo')
				.then((response) => {
					store.commit('login', response.data)
					next()
				})
				.catch(() => {
					next({
						path: '/login',
						query: { redirect: to.fullPath },
					})
				})
		} else {
			next()
		}
	} else {
		next()
	}
})

export default router
