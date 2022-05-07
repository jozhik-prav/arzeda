<template>
	<v-card>
		<v-card-title>
			<h2 class="mb-2">
				{{ restaurant.name ? restaurant.name : 'Название ресторана' }}
			</h2>
			<v-spacer></v-spacer>
			<v-btn
				color="primary"
				dark
				fab
				small
				@click="isEditing = !isEditing"
			>
				<v-icon v-if="isEditing"> mdi-close </v-icon>
				<v-icon v-else> mdi-pencil </v-icon>
			</v-btn>
		</v-card-title>
		<v-form class="mx-4" v-model="validate">
			<v-text-field
				label="Имя ресторана"
				v-model="restaurant.name"
				:rules="[(v) => !!v || 'Поле обязательное']"
				:disabled="!isEditing"
				required
			></v-text-field>
			<v-textarea
				label="Описание"
				v-model="restaurant.description"
				:rules="[(v) => !!v || 'Поле обязательное']"
				:disabled="!isEditing"
				required
			></v-textarea>
			<v-text-field
				label="Изображение ресторана"
				v-model="restaurant.image"
				:rules="[(v) => !!v || 'Поле обязательное']"
				:disabled="!isEditing"
				required
			></v-text-field>
			<v-text-field
				label="Адрес ресторана"
				v-model="restaurant.address"
				:rules="[(v) => !!v || 'Поле обязательное']"
				:disabled="!isEditing"
				required
			></v-text-field>
			<v-select
				:items="categories"
				item-text="name"
				item-value="id"
				:disabled="!isEditing"
				label="Категории"
				v-model="restaurant.categories"
				:rules="[(v) => v.length > 0 || 'Выберите хоть одну категорию']"
				multiple
				chips
				required
			></v-select>
			<v-row>
				<v-col cols="6" sm="5">
					<v-menu
						ref="menuStart"
						v-model="menuStart"
						:close-on-content-click="false"
						:nudge-right="40"
						:return-value.sync="restaurant.timeWorkStart"
						transition="scale-transition"
						offset-y
						max-width="290px"
						min-width="290px"
					>
						<template v-slot:activator="{ on, attrs }">
							<v-text-field
								:disabled="!isEditing"
								v-model="restaurant.timeWorkStart"
								:rules="[(v) => !!v || 'Поле обязательное']"
								label="Начало работы"
								prepend-icon="mdi-clock-time-four-outline"
								readonly
								v-bind="attrs"
								v-on="on"
							></v-text-field>
						</template>
						<v-time-picker
							v-if="menuStart"
							v-model="restaurant.timeWorkStart"
							full-width
							format="24hr"
							@click:minute="
								$refs.menuStart.save(restaurant.timeWorkStart)
							"
						></v-time-picker>
					</v-menu>
				</v-col>
				<v-col cols="6" sm="5">
					<v-menu
						ref="menuEnd"
						v-model="menuEnd"
						:close-on-content-click="false"
						:nudge-right="40"
						:return-value.sync="restaurant.timeWorkEnd"
						transition="scale-transition"
						offset-y
						max-width="290px"
						min-width="290px"
					>
						<template v-slot:activator="{ on, attrs }">
							<v-text-field
								:disabled="!isEditing"
								v-model="restaurant.timeWorkEnd"
								:rules="[(v) => !!v || 'Поле обязательное']"
								label="Окончание работы"
								prepend-icon="mdi-clock-time-four-outline"
								readonly
								v-bind="attrs"
								v-on="on"
							></v-text-field>
						</template>
						<v-time-picker
							v-if="menuEnd"
							v-model="restaurant.timeWorkEnd"
							full-width
							format="24hr"
							@click:minute="
								$refs.menuEnd.save(restaurant.timeWorkEnd)
							"
						></v-time-picker>
					</v-menu>
				</v-col>
			</v-row>
			<v-text-field
				label="Минимальная сумма"
				type="number"
				v-model="restaurant.minSum"
				:rules="[(v) => !!v || 'Поле обязательное']"
				:disabled="!isEditing"
				required
			></v-text-field>
			<v-text-field
				label="Цена доставки"
				type="number"
				v-model="restaurant.deliveryPrice"
				:rules="[(v) => v >= 0 || 'Поле обязательное']"
				:disabled="!isEditing"
				required
			></v-text-field>
		</v-form>
		<v-card-actions class="d-flex mb-3 mx-4">
			<v-spacer></v-spacer>
			<v-btn
				:disabled="!isEditing || !validate"
				color="success"
				@click="save"
			>
				Save
			</v-btn>
		</v-card-actions>
	</v-card>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import {
	Category,
	Restaurant,
	RestaurantApiModel,
	RestaurantToApiModel,
	RestaurantToModel,
} from '@/Types'

@Component({
	components: {},
})
export default class RestaurantView extends Vue {
	validate = false
	isEditing = false
	menuStart = false
	menuEnd = false
	categories: Category[] = []
	restaurant: Restaurant = {
		id: '',
		name: '',
		description: '',
		image: '',
		address: '',
		timeWorkStart: '',
		timeWorkEnd: '',
		categories: [],
		products: [],
		deliveryPrice: 0,
		minSum: 0,
	}
	async mounted(): Promise<void> {
		try {
			const user = (await this.$axios.get('/api/account/userInfo')).data
			this.$store.commit('login', user)
		} catch {
			this.$router.push('/login')
			return
		}
		this.categories = (await this.$axios.get('/api/category')).data
		const restaurantResponse = await this.$axios.get<RestaurantApiModel>(
			'/api/manager/restaurantInfo?r=' + Math.random()
		)
		if (restaurantResponse.status === 204) {
			this.isEditing = true
		} else {
			this.restaurant = RestaurantToModel(restaurantResponse.data)
			this.$store.commit('restaurantId', this.restaurant.id)
		}
	}

	save(): void {
		if (this.restaurant.id === '') {
			const restaurant = RestaurantToApiModel(this.restaurant)
			this.$axios
				.post('/api/restaurant', restaurant)
				.then((result) => {
					this.restaurant.id = result.data.id
					this.isEditing = !this.isEditing
				})
				.catch((e) => {
					console.log(e)
				})
		} else {
			const restaurant = RestaurantToApiModel(this.restaurant)
			this.$axios
				.put('/api/restaurant/' + restaurant.id, restaurant)
				.then((result) => {
					this.restaurant.id = result.data.id
					this.isEditing = !this.isEditing
				})
				.catch((e) => {
					console.log(e)
				})
		}
	}
}
</script>
