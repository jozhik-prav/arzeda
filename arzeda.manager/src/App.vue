<template>
	<v-app>
		<v-app-bar
			app
			color="primary"
			dark
			clipped-left
			v-if="this.$store.getters.isLogin"
		>
			<v-app-bar-nav-icon @click.stop="mini = !mini"></v-app-bar-nav-icon>
			<router-link to="/">
				<v-img
					alt="Vuetify Logo"
					class="shrink mr-2"
					contain
					src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
					transition="scale-transition"
					width="40"
			/></router-link>

			<v-toolbar-title>Arzeda.Manager</v-toolbar-title>
		</v-app-bar>
		<v-navigation-drawer
			:mini-variant.sync="mini"
			clipped
			app
			v-if="this.$store.getters.isLogin"
		>
			<v-list nav>
				<v-list-item link to="/restaurant">
					<v-list-item-icon>
						<v-icon>mdi-folder</v-icon>
					</v-list-item-icon>
					<v-list-item-title>Ресторан</v-list-item-title>
				</v-list-item>
				<v-list-item link to="/products">
					<v-list-item-icon>
						<v-icon>mdi-folder</v-icon>
					</v-list-item-icon>
					<v-list-item-title>Товары</v-list-item-title>
				</v-list-item>
			</v-list>
		</v-navigation-drawer>
		<v-main>
			<v-container fluid>
				<router-view></router-view>
			</v-container>
		</v-main>
	</v-app>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component
export default class App extends Vue {
	mini = false
}
</script>
