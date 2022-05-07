<template>
	<v-card>
		<v-toolbar flat>
			<v-toolbar-title>User Profile</v-toolbar-title>
		</v-toolbar>
		<v-tabs vertical>
			<v-tab href="#about" class="justify-start">
				<v-icon left>
					mdi-account
				</v-icon>
				Мои данные
			</v-tab>
			<v-tab href="#orders" class="justify-start">
				<v-icon left>
					mdi-lock
				</v-icon>
				Заказы
			</v-tab>

			<v-tab-item value="about">
				<v-toolbar flat>
					<v-spacer></v-spacer>
					<v-btn
						color="primary"
						dark
						fab
						small
						@click="isEditing = !isEditing"
					>
						<v-icon v-if="isEditing">
							mdi-close
						</v-icon>
						<v-icon v-else>
							mdi-pencil
						</v-icon>
					</v-btn>
				</v-toolbar>
				<v-form class="mx-4">
					<v-text-field
						label="Имя"
						v-model="account.name"
						:disabled="!isEditing"
					></v-text-field>
					<v-text-field
						label="E-mail"
						v-model="account.email"
						:disabled="!isEditing"
					></v-text-field>
					<v-text-field
						label="Адрес"
						v-model="account.address"
						:disabled="!isEditing"
					></v-text-field>
					<v-row>
						<v-col>
							<v-text-field
								label="Подъезд"
								v-model="account.entrance"
								:disabled="!isEditing"
							></v-text-field>
						</v-col>
						<v-col>
							<v-text-field
								label="Домофон"
								v-model="account.intercom"
								:disabled="!isEditing"
							></v-text-field>
						</v-col>
						<v-col>
							<v-text-field
								label="Этаж"
								v-model="account.floor"
								:disabled="!isEditing"
							></v-text-field>
						</v-col>
						<v-col>
							<v-text-field
								label="Квартира"
								v-model="account.flat"
								:disabled="!isEditing"
							></v-text-field>
						</v-col>
					</v-row>
				</v-form>
				<div class="d-flex mb-3 mx-4">
					<v-spacer></v-spacer>
					<v-btn :disabled="!isEditing" color="success" @click="save">
						Save
					</v-btn>
				</div>
			</v-tab-item>
			<v-tab-item value="orders">
				<v-card
					outlined
					class="pa-3 mb-5"
					v-for="order in orders"
					:key="order.id"
				>
					<div class="d-flex">
						<div style="flex: 1 1 auto">
							<h3 class="mb-5">{{ order.restaurant.name }}</h3>
							<p class="mb-1">{{ order.date }}</p>
							<p>{{ order.address }}</p>
						</div>
						<div style="flex: 0 0 auto">
							<v-img
								:src="order.restaurant.image"
								aspect-ratio="1"
								class="grey lighten-2"
								width="126px"
							></v-img>
						</div>
					</div>
					<v-divider class="mt-5 mb-3"></v-divider>
					<v-row
						v-for="orderLine in order.orderLines"
						:key="orderLine.productId"
					>
						<v-col>{{ orderLine.product.name }}</v-col>
						<v-col cols="1" class="text-right"
							>{{ orderLine.quantity }} шт</v-col
						>
						<v-col cols="1" class="text-right"
							>{{ orderLine.price }} ₽</v-col
						>
					</v-row>
					<v-row class="text-h6">
						<v-col>Итого</v-col>
						<v-col cols="1" class="text-right"
							>{{ order.price }} ₽</v-col
						>
					</v-row>
				</v-card>
			</v-tab-item>
		</v-tabs>
	</v-card>
</template>

<script lang="ts">
import { Account } from '@/Types'
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class AccountView extends Vue {
	account: Account = {
		id: '',
		name: '',
		email: '',
		address: '',
		entrance: '',
		intercom: '',
		floor: 0,
		flat: '',
	}
	orders: [] = []
	isEditing = false

	async mounted() {
		this.$axios
			.get<Account>('/api/account/userInfoFull')
			.then(responce => {
				this.account = responce.data
			})
			.catch(e => console.log(e))
		this.orders = (await this.$axios.get('/api/order/getByAccount')).data
	}

	save(): void {
		this.$axios
			.put('/api/account/update', this.account)
			.then(() => (this.isEditing = !this.isEditing))
			.catch(e => console.log(e))
	}
}
</script>
