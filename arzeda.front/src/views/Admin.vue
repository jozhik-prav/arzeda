<template>
	<div>
		<template>
			<v-data-table
				:headers="headers"
				:items="restaurants"
				:items-per-page="5"
				class="elevation-1"
			>
				<template v-slot:top>
					<v-toolbar flat>
						<v-toolbar-title>Рестораны</v-toolbar-title>
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
									<span class="text-h5">{{ formTitle }}</span>
								</v-card-title>

								<v-card-text>
									<v-container>
										<v-row>
											<v-col cols="12" sm="6" md="4">
												<v-text-field
													v-model="editedItem.name"
													label="Restaurant name"
												></v-text-field>
											</v-col>
											<v-col cols="12" sm="6" md="4">
												<v-text-field
													v-model="editedItem.address"
													label="address"
												></v-text-field>
											</v-col>
											<v-col cols="12" sm="6" md="4">
												<v-text-field
													v-model="editedItem.status"
													label="Status"
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
									ресторан?</v-card-title
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
		</template>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class Admin extends Vue {
	headers = [
		{
			text: 'Name',
			align: 'start',
			sortable: false,
			value: 'name',
		},
		{
			text: 'Address',
			align: 'start',
			sortable: false,
			value: 'address',
		},
		{
			text: 'Status',
			align: 'start',
			sortable: false,
			value: 'status',
		},
	]
	restaurants: [] = []
	editedIndex = -1
	editedItem = {
		name: '',
		address: '',
		status: '',
	}
	defaultItem = {
		name: '',
		address: '',
		status: '',
	}
	get formTitle() {
		return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
	}
	dialog = false
	dialogDelete = false
	editItem(item: any) {
		this.editedIndex = this.restaurants.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialog = true
	}

	deleteItem(item: any) {
		this.editedIndex = this.restaurants.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialogDelete = true
	}

	deleteItemConfirm() {
		this.restaurants.splice(this.editedIndex, 1)
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
			Object.assign(this.restaurants[this.editedIndex], this.editedItem)
		} else {
			this.restaurants.push(this.editedItem)
		}
		this.close()
	}
}
</script>
