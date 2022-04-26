<template>
	<v-app-bar app color="primary" dark>
		<v-row align="center" no-gutters>
			<v-col lg="1" class="d-flex align-center"
				><router-link to="/">
					<v-img
						alt="Vuetify Logo"
						class="shrink mr-2"
						contain
						src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
						transition="scale-transition"
						width="40"
				/></router-link>

				<v-toolbar-title>Arz.Еда</v-toolbar-title>
			</v-col>
			<v-col>
				<v-text-field
					label="Адрес доставки"
					prepend-inner-icon="mdi-map-marker"
					hide-details="auto"
				></v-text-field>
			</v-col>
			<v-col lg="2" class="d-flex justify-end align-center">
				<router-link to="/order"
					><v-btn text color="white" class="mr-2">
						<v-icon left>
							mdi-cart-outline
						</v-icon>
						<span v-if="!$store.getters.orderIsEmpty"
							>{{ $store.getters.totalSum }} ₽</span
						>
					</v-btn></router-link
				>

				<router-link to="/login" v-if="!$store.getters.isLogin">
					<v-btn text color="white" dark>Войти</v-btn>
				</router-link>
				<v-menu offset-y v-if="$store.getters.isLogin">
					<template v-slot:activator="{ on, attrs }">
						<v-btn text color="white" dark v-bind="attrs" v-on="on">
							{{ $store.state.user.name }}
						</v-btn>
					</template>
					<v-list>
						<v-list-item>
							<v-list-item-content>
								<v-list-item-title class="text-h6">
									{{ $store.state.user.name }}
								</v-list-item-title>
								<v-list-item-subtitle>{{
									$store.state.user.email
								}}</v-list-item-subtitle>
							</v-list-item-content>
						</v-list-item>
						<v-divider></v-divider>
						<v-list-item link to="/account">
							<v-list-item-title
								>Личный кабинет</v-list-item-title
							>
						</v-list-item>
						<v-list-item link @click="logout">
							<v-list-item-title>Выйти</v-list-item-title>
						</v-list-item>
					</v-list>
				</v-menu>
			</v-col>
		</v-row>
	</v-app-bar>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component
export default class Header extends Vue {
	logout() {
		this.$axios
			.post('/api/account/logout')
			.then(() => {
				this.$store.commit('logout')
			})
			.catch(e => {
				console.log(e)
			})
	}
}
</script>
