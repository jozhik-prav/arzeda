<template>
	<v-data-table
		:headers="headers"
		:items="products"
		:items-per-page="5"
		class="elevation-1"
	>
		<template v-slot:top>
			<v-toolbar flat>
				<v-toolbar-title>Рестораны</v-toolbar-title>
				<v-spacer></v-spacer>
				<v-dialog v-model="dialog" max-width="500px">
					<template v-slot:activator="{ on, attrs }">
						<v-btn color="primary" dark v-bind="attrs" v-on="on">
							Добавить
						</v-btn>
					</template>
					<v-card>
						<v-card-title>
							<span class="text-h5">{{ formTitle }}</span>
						</v-card-title>

						<v-card-text>
							<v-container>
								<v-row>
									<v-col cols="6">
										<v-img
											:src="editedItem.image"
											aspect-ratio="1"
											class="grey lighten-2 mx-auto"
											width="178px"
										></v-img>
										<v-file-input
											accept="image/*"
											label="Изображение товара"
											prepend-icon="mdi-camera"
											@change="encodeImageFileAsURL"
										></v-file-input>
									</v-col>
									<v-col>
										<v-text-field
											v-model="editedItem.name"
											label="Название товара"
										></v-text-field>
										<v-textarea
											v-model="editedItem.description"
											label="Описание"
										></v-textarea>
									</v-col>
								</v-row>
								<v-text-field
									v-model="editedItem.price"
									type="number"
									label="Цена"
								></v-text-field>
							</v-container>
						</v-card-text>

						<v-card-actions>
							<v-spacer></v-spacer>
							<v-btn color="blue darken-1" text @click="close">
								Отмена
							</v-btn>
							<v-btn color="blue darken-1" text @click="save">
								Сохранить
							</v-btn>
						</v-card-actions>
					</v-card>
				</v-dialog>
				<v-dialog v-model="dialogDelete" max-width="500px">
					<v-card>
						<v-card-title class="text-h5"
							>Вы уверены что хотите удалить этот
							товар?</v-card-title
						>
						<v-card-actions>
							<v-spacer></v-spacer>
							<v-btn
								color="blue darken-1"
								text
								@click="closeDelete"
								>Омена</v-btn
							>
							<v-btn
								color="blue darken-1"
								text
								@click="deleteItemConfirm"
								>OK</v-btn
							>
							<v-spacer></v-spacer>
						</v-card-actions>
					</v-card>
				</v-dialog>
			</v-toolbar>
		</template>
		<template v-slot:item.actions="{ item }">
			<v-icon small class="mr-2" @click="editItem(item)">
				mdi-pencil
			</v-icon>
			<v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
		</template>
	</v-data-table>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import {
	Category,
	Product,
	Restaurant,
	RestaurantApiModel,
	RestaurantToApiModel,
	RestaurantToModel,
} from '@/Types'

@Component({
	components: {},
})
export default class ProductsView extends Vue {
	headers = [
		{
			text: 'Название товара',
			align: 'start',
			sortable: false,
			value: 'name',
		},
		{
			text: 'Описание',
			align: 'start',
			sortable: false,
			value: 'description',
		},
		{
			text: 'Цена',
			align: 'start',
			sortable: false,
			value: 'price',
		},
		{
			text: 'Действия',
			align: 'start',
			sortable: false,
			value: 'actions',
		},
	]
	products: Product[] = []
	editedIndex = -1
	editedItem: Product = {
		id: '',
		name: '',
		description: '',
		price: 0,
		image: '',
	}
	defaultItem: Product = {
		id: '',
		name: '',
		description: '',
		price: 0,
		image: '',
	}
	get formTitle() {
		return this.editedIndex === -1 ? 'Новый товар' : 'Редактирование'
	}
	dialog = false
	dialogDelete = false

	mounted() {
		this.$axios
			.get<Product[]>(
				`api/restaurant/${this.$store.state.restaurantId}/products`
			)
			.then((response) => {
				this.products = response.data
			})
			.catch((e) => console.log(e))
	}

	encodeImageFileAsURL(event): void {
		// eslint-disable-next-line @typescript-eslint/no-this-alias
		let me = this
		console.log(event)
		console.log(event.file)
		console.log(typeof event)
		var file = event
		var reader = new FileReader()
		reader.onloadend = function () {
			console.log('RESULT', reader.result)
			me.editedItem.image = reader.result
		}
		reader.readAsDataURL(file)
	}

	editItem(item: any) {
		this.editedIndex = this.products.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialog = true
	}

	deleteItem(item: any) {
		this.editedIndex = this.products.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialogDelete = true
	}

	deleteItemConfirm() {
		this.$axios
			.delete(`api/restaurant/${this.editedItem.id}/product`)
			.then(() => {
				this.products.splice(this.editedIndex, 1)
				this.closeDelete()
			})
			.catch((e) => console.log(e))
	}

	close() {
		this.dialog = false
		this.$nextTick(() => {
			this.editedItem = Object.assign({}, this.defaultItem)
			this.editedIndex = -1
		})
	}

	closeDelete() {
		this.dialogDelete = false
		this.$nextTick(() => {
			this.editedItem = Object.assign({}, this.defaultItem)
			this.editedIndex = -1
		})
	}

	save(): void {
		if (this.editedIndex > -1) {
			this.$axios
				.put(
					`/api/restaurant/${this.editedItem.id}/product`,
					this.editedItem
				)
				.then(() => {
					Object.assign(
						this.products[this.editedIndex],
						this.editedItem
					)
					this.close()
				})
				.catch((e) => console.log(e))
		} else {
			this.$axios
				.post(
					`/api/restaurant/${this.$store.state.restaurantId}/product`,
					this.editedItem
				)
				.then((response) => {
					this.products.push({
						...this.editedItem,
						id: response.data,
					})
					this.close()
				})
				.catch((e) => console.log(e))
		}
	}
}
</script>
