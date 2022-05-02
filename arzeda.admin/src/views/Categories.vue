<template>
	<v-data-table
		:headers="headers"
		:items="categories"
		:items-per-page="5"
		class="elevation-1"
	>
		<template v-slot:top>
			<v-toolbar flat>
				<v-toolbar-title>Категории</v-toolbar-title>
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
									<v-col cols="12" sm="6" md="4">
										<v-text-field
											v-model="editedItem.name"
											label="Имя категории"
										></v-text-field>
									</v-col>
								</v-row>
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
							>Вы уверены что хотите удалить эту
							категорию?</v-card-title
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
			<v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
		</template>
	</v-data-table>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { Category } from '@/Types'

@Component({
	components: {},
})
export default class Categories extends Vue {
	headers = [
		{
			text: 'Навзание категории',
			align: 'start',
			sortable: false,
			value: 'name',
		},
		{
			text: 'Действия',
			align: 'start',
			sortable: false,
			value: 'actions',
		},
	]
	categories: Category[] = []
	editedIndex = -1
	editedItem = {
		id: '',
		name: '',
	}
	defaultItem = {
		id: '',
		name: '',
	}
	get formTitle() {
		return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
	}
	dialog = false
	dialogDelete = false
	editItem(item: any) {
		this.editedIndex = this.categories.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialog = true
	}

	deleteItem(item: any) {
		this.editedIndex = this.categories.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialogDelete = true
	}

	deleteItemConfirm() {
		this.$axios
			.delete('/api/category/' + this.editedItem.id)
			.then((result) => {
				this.categories.splice(this.editedIndex, 1)
				this.closeDelete()
			})
			.catch((reason) => console.log(reason))
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
		this.$axios
			.post('/api/category/' + this.editedItem.name)
			.then((result) => {
				this.editedItem.id = result.data
				this.categories.push(this.editedItem)
				this.close()
			})
			.catch((reason) => console.log(reason))
	}
	mounted() {
		this.$axios
			.get('/api/category')
			.then((result) => {
				this.categories = result.data
				console.log(this.categories)
			})
			.catch()
	}
}
</script>
