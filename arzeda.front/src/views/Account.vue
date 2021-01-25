<template>
	<div>
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
				<v-col cols="1" class="text-right">{{ order.price }} ₽</v-col>
			</v-row>
		</v-card>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class Account extends Vue {
	orders: [] = []

	async mounted() {
		this.orders = (await this.$axios.get('/api/order')).data
	}
}
</script>
