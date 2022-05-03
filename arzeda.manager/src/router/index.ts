import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Restaurant from '../views/Restaurant.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
	{
		path: '/',
		name: 'Restaurant',
		component: Restaurant,
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
	},
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
})

export default router
