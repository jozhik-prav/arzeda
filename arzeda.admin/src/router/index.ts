import store from '@/store'
import axios from 'axios'
import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Users from '../views/Users.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
	{
		path: '/',
		name: 'Users',
		component: Users,
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
		path: '/users',
		name: 'Users',
		component: () => import('../views/Users.vue'),
		meta: {
			requiresAuth: true,
		},
	},
	{
		path: '/categories',
		name: 'Categories',
		component: () => import('../views/Categories.vue'),
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
		console.log(1)
		if (!store.getters.isLogin) {
			console.log(2)
			axios
				.get('/api/account/userInfo')
				.then((response) => {
					console.log(3)
					store.commit('login', response.data)
					next()
				})
				.catch(() => {
					console.log(4)
					next({
						path: '/login',
						query: { redirect: to.fullPath },
					})
				})
		} else {
			console.log(5)
			next()
		}
	} else {
		console.log(6)
		next()
	}
})

export default router
