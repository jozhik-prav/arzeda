import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
	{
		path: '/',
		name: 'Home',
		component: Home,
	},
	{
		path: '/restaurant/:id',
		name: 'Restaurant',
		component: () =>
			import(/* webpackChunkName: "about" */ '../views/Restaurant.vue'),
	},
	{
		path: '/order',
		name: 'Order',
		component: () => import('../views/Order.vue'),
	},
	{
		path: '/account',
		name: 'Account',
		component: () => import('../views/Account.vue'),
	},
	{
		path: '/admin',
		name: 'Admin',
		component: () => import('../views/Admin.vue'),
	},
	{
		path: '/admin-restaurant',
		name: 'AdminRestaurant',
		component: () => import('../views/Admin-restaurant.vue'),
	},
	{
		path: '/admin-courier',
		name: 'AdminCourier',
		component: () => import('../views/Admin-courier.vue'),
	},
	{
		path: '/login',
		name: 'Login',
		component: () => import('../views/Login.vue'),
	},
	{
		path: '/registration',
		name: 'Registration',
		component: () => import('../views/Registration.vue'),
	},
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
	scrollBehavior: function(to, from, savedPosition) {
		if (to.hash) {
			return { selector: to.hash }
		} else {
			return { x: 0, y: 0 }
		}
	},
})

export default router
