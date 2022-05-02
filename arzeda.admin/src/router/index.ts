import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Users from '../views/Users.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
	{
		path: '/',
		name: 'Users',
		component: Users,
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
	},
	{
		path: '/categories',
		name: 'Categories',
		component: () => import('../views/Categories.vue'),
	},
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
})

export default router
