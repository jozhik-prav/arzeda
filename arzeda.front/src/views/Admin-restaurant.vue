<template>
	<v-card>
		<v-card-title>Название ресторана</v-card-title>
		<v-tabs vertical>
			<v-tab href="#about" class="justify-start">
				<v-icon left>
					mdi-account
				</v-icon>
				О ресторане
			</v-tab>
			<v-tab href="#product" class="justify-start">
				<v-icon left>
					mdi-lock
				</v-icon>
				Товары
			</v-tab>
			<v-tab href="#orders" class="justify-start">
				<v-icon left>
					mdi-access-point
				</v-icon>
				Заказы
			</v-tab>
			<v-tab href="#reviews" class="justify-start">
				<v-icon left>
					mdi-access-point
				</v-icon>
				Отзывы
			</v-tab>

			<v-tab-item value="about">
				<v-toolbar flat>
					<v-toolbar-title class="font-weight-light">
						Название ресторана
					</v-toolbar-title>
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
						label="Имя ресторана"
						:disabled="!isEditing"
					></v-text-field>
					<v-textarea
						label="Описание"
						value=""
						:disabled="!isEditing"
					></v-textarea>
					<v-text-field
						label="Адрес ресторана"
						:disabled="!isEditing"
					></v-text-field>
					<v-select
						:items="items"
						:disabled="!isEditing"
						label="Категории"
						multiple
						chips
					></v-select>
					<v-row>
						<v-col cols="6" sm="5">
							<v-menu
								ref="menuStart"
								v-model="menuStart"
								:close-on-content-click="false"
								:nudge-right="40"
								:return-value.sync="timeStart"
								transition="scale-transition"
								offset-y
								max-width="290px"
								min-width="290px"
							>
								<template v-slot:activator="{ on, attrs }">
									<v-text-field
										:disabled="!isEditing"
										v-model="timeStart"
										label="Picker in menu"
										prepend-icon="mdi-clock-time-four-outline"
										readonly
										v-bind="attrs"
										v-on="on"
									></v-text-field>
								</template>
								<v-time-picker
									v-if="menuStart"
									v-model="timeStart"
									full-width
									format="24hr"
									@click:minute="
										$refs.menuStart.save(timeStart)
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
								:return-value.sync="timeEnd"
								transition="scale-transition"
								offset-y
								max-width="290px"
								min-width="290px"
							>
								<template v-slot:activator="{ on, attrs }">
									<v-text-field
										:disabled="!isEditing"
										v-model="timeEnd"
										label="Picker in menu"
										prepend-icon="mdi-clock-time-four-outline"
										readonly
										v-bind="attrs"
										v-on="on"
									></v-text-field>
								</template>
								<v-time-picker
									v-if="menuEnd"
									v-model="timeEnd"
									full-width
									format="24hr"
									@click:minute="$refs.menuEnd.save(timeEnd)"
								></v-time-picker>
							</v-menu>
						</v-col>
					</v-row>
					<v-text-field
						label="Минимальная сумма"
						type="number"
						:disabled="!isEditing"
					></v-text-field>
				</v-form>
				<div class="d-flex mb-3 mx-4">
					<v-spacer></v-spacer>
					<v-btn
						:disabled="!isEditing"
						color="success"
						@click="isEditing = !isEditing"
					>
						Save
					</v-btn>
				</div>
			</v-tab-item>
			<v-tab-item value="product">
				<v-data-table
					:headers="headers"
					:items="products"
					:items-per-page="5"
					class="elevation-1"
				>
					<template v-slot:top>
						<v-toolbar flat>
							<v-toolbar-title>Товары</v-toolbar-title>
							<v-spacer></v-spacer>
							<v-dialog v-model="dialog" max-width="500px">
								<template v-slot:activator="{ on, attrs }">
									<v-btn
										color="primary"
										dark
										v-bind="attrs"
										v-on="on"
									>
										Добавить
									</v-btn>
								</template>
								<v-card>
									<v-card-title>
										<span class="text-h5">{{
											formTitle
										}}</span>
									</v-card-title>

									<v-card-text>
										<v-container>
											<v-row>
												<v-col
													cols="12"
													sm="12"
													md="12"
												>
													<v-text-field
														v-model="
															editedItem.name
														"
														label="Restaurant name"
													></v-text-field>
												</v-col>
												<v-col
													cols="12"
													sm="12"
													md="12"
												>
													<v-textarea
														v-model="
															editedItem.description
														"
														label="Description"
													></v-textarea>
												</v-col>
												<v-col cols="12" sm="6" md="4">
													<v-text-field
														v-model="
															editedItem.price
														"
														type="number"
														label="Price"
													></v-text-field>
												</v-col>
											</v-row>
										</v-container>
									</v-card-text>

									<v-card-actions>
										<v-spacer></v-spacer>
										<v-btn
											color="blue darken-1"
											text
											@click="close"
										>
											Отмена
										</v-btn>
										<v-btn
											color="blue darken-1"
											text
											@click="save"
										>
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
						<v-icon small @click="deleteItem(item)">
							mdi-delete
						</v-icon>
					</template>
				</v-data-table>
			</v-tab-item>
			<v-tab-item value="orders">
				<v-data-table
					:headers="headersOrders"
					:items="orders"
					item-key="name"
					class="elevation-1"
					:search="search"
				>
					<template v-slot:top>
						<v-row>
							<v-col cols="12" sm="6" md="3">
								<v-text-field
									v-model="date"
									type="number"
									label="Data"
								></v-text-field>
							</v-col>
							<v-col cols="12" sm="6" md="3">
								<v-text-field
									v-model="price"
									type="number"
									label="Price"
								></v-text-field>
							</v-col>
							<v-col cols="12" sm="6" md="3">
								<v-text-field
									v-model="status"
									type="number"
									label="Status"
								></v-text-field>
							</v-col>
						</v-row>
					</template>
				</v-data-table>
			</v-tab-item>
			<v-tab-item value="reviews">
				<v-card flat>
					<v-card-text>
						<p>
							Отзывы
						</p>
					</v-card-text>
				</v-card>
			</v-tab-item>
		</v-tabs>
	</v-card>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class AdminRestaurant extends Vue {
	items = [
		'Бургеры',
		'Суши',
		'Пицца',
		'Десерты',
		'Шашлыки',
		'Здоровая еда',
		'Мясо и рыба',
	]
	timeStart = ''
	timeEnd = ''
	menuStart = false
	menuEnd = false
	isEditing = false
	headers = [
		{
			text: 'Image',
			align: 'start',
			sortable: false,
			value: 'image',
		},
		{
			text: 'Name',
			align: 'start',
			sortable: false,
			value: 'name',
		},
		{
			text: 'Description',
			align: 'start',
			sortable: false,
			value: 'description',
		},
		{
			text: 'Price',
			align: 'start',
			sortable: false,
			value: 'price',
		},
	]
	products: [] = []
	editedIndex = -1
	editedItem = {
		image: '',
		name: '',
		description: '',
		price: 0,
	}
	defaultItem = {
		image: '',
		name: '',
		description: '',
		price: 0,
	}
	get formTitle() {
		return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
	}
	dialog = false
	dialogDelete = false
	headersOrders = [
		{
			text: 'Date',
			align: 'start',
			value: 'date',
			filter: () => {
				return 1
			},
		},
		{
			text: 'Address',
			align: 'start',
			value: 'address',
			filter: () => {
				return 1
			},
		},
		{
			text: 'Price',
			align: 'start',
			value: 'price',
			filter: () => {
				return 1
			},
		},
		{
			text: 'Comment',
			align: 'start',
			value: 'comment',
			filter: () => {
				return 1
			},
		},
		{
			text: 'OrderLines',
			align: 'start',
			value: 'orderLines',
			filter: () => {
				return 1
			},
		},
		{
			text: 'Status',
			align: 'start',
			value: 'status',
			filter: () => {
				return 1
			},
		},
	]
	orders: [] = []
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
		this.products.splice(this.editedIndex, 1)
		this.closeDelete()
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

	save() {
		if (this.editedIndex > -1) {
			Object.assign(this.products[this.editedIndex], this.editedItem)
		} else {
			this.products.push(this.editedItem)
		}
		this.close()
	}
}
</script>
