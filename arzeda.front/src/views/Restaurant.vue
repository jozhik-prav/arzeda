<template>
	<div>
		<div class="d-flex" v-if="restaurant">
			<div style="flex: 1 1 auto">
				<h1>{{ restaurant.name }}</h1>
				<v-chip-group>
					<v-chip class="ma-2">30 мин</v-chip>
					<v-chip class="ma-2">От {{ restaurant.minSum }} ₽</v-chip>
					<v-menu offset-y>
						<template v-slot:activator="{ on, attrs }">
							<v-chip class="ma-2" v-bind="attrs" v-on="on"
								>i</v-chip
							>
						</template>
						<v-card class="pa-2 grey--text">
							<h3 class="black--text">{{ restaurant.name }}</h3>
							<p>
								<span>{{ restaurant.address }}</span> &middot;
								<span
									>Режим работы:
									{{ restaurant.timeWork }}</span
								>
							</p>
							<p>
								<span
									v-for="category in restaurant.categories"
									:key="category.id"
									>{{ category.name }}</span
								>
							</p>
						</v-card>
					</v-menu>
				</v-chip-group>
			</div>
			<div style="flex: 0 0 auto">
				<v-img
					:src="restaurant.image"
					aspect-ratio="1"
					class="grey lighten-2"
					width="126px"
				></v-img>
			</div>
		</div>
		<div>
			<div class="grid-container">
				<v-card
					class="mx-auto"
					max-width="344"
					v-for="product in restaurant.products"
					:key="product.id"
				>
					<v-img :src="product.image" height="200px" contain></v-img>

					<v-card-title>
						{{ product.name }}
					</v-card-title>
					<v-card-text>
						{{ product.description }}
					</v-card-text>

					<v-card-actions class="justify-space-between">
						<div>{{ product.price }} ₽</div>
						<v-btn
							color="blue"
							class="white--text"
							@click="addToOrder(product)"
						>
							Добавить в корзину
						</v-btn>
					</v-card-actions>
				</v-card>
			</div>
		</div>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { Restaurant, Product } from '@/Types'

@Component
export default class RestaurantView extends Vue {
	restaurant: Restaurant | {} = {}

	async mounted() {
		const response = await this.$axios.get(
			'/api/restaurant/' + this.$route.params.id
		)
		this.restaurant = response.data
	}

	addToOrder(product: Product) {
		this.$store.commit('addProduct', {
			product: product,
			count: 1,
		})
	}
}
</script>

<style lang="scss" scoped>
.grid-container {
	display: grid;
	grid-gap: 1rem;
	grid-template-columns: repeat(auto-fit, 344px);
}
</style>
