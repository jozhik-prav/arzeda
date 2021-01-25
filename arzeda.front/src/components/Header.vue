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

				<router-link to="/account"
					><v-avatar color="orange" size="50">
						<span class="white--text headline">JP</span>
					</v-avatar></router-link
				>
			</v-col>
		</v-row>
	</v-app-bar>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component
export default class Header extends Vue {}
</script>
