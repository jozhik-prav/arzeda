<template>
	<div>
		<h2 class="mb-2">Рестораны</h2>
		<v-text-field
			outlined
			label="Название, кухня или блюдо..."
			prepend-inner-icon="mdi-magnify"
		></v-text-field>
		<v-chip-group active-class="blue white--text">
			<v-chip class="ma-2">Все</v-chip>
			<v-chip class="ma-2">Бургеры</v-chip>
			<v-chip class="ma-2">Суши</v-chip>
			<v-chip class="ma-2">Пицца</v-chip>
			<v-chip class="ma-2">Десерты</v-chip>
			<v-chip class="ma-2">Шашлыки</v-chip>
			<v-chip class="ma-2">Здоровая еда</v-chip>
			<v-chip class="ma-2">Мясо и рыба</v-chip>
		</v-chip-group>
		<div class="grid-container">
			<router-link
				v-for="restaurant in restaurants"
				:key="restaurant.id"
				:to="'/restaurant/' + restaurant.id"
				><v-card class="mx-auto" max-width="344">
					<v-img :src="restaurant.image" height="200px"></v-img>

					<v-card-title>
						{{ restaurant.name }}
					</v-card-title>

					<v-card-actions>
						<v-chip-group active-class="blue white--text">
							<v-chip class="ma-2">30 мин</v-chip>
							<v-chip class="ma-2"
								>От {{ restaurant.minSum }} ₽</v-chip
							>
						</v-chip-group>
					</v-card-actions>
				</v-card></router-link
			>
		</div>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { Restaurant } from '@/Types'

@Component({
	components: {},
})
export default class Home extends Vue {
	restaurants: Restaurant[] = []

	async mounted() {
		this.restaurants = (await this.$axios.get('/api/restaurant')).data
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
