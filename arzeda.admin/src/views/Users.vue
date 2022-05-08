<template>
	<v-data-table
		:headers="headers"
		:items="users"
		:items-per-page="5"
		class="elevation-1"
	>
		<template v-slot:top>
			<v-toolbar flat>
				<v-toolbar-title>Пользователи</v-toolbar-title>
				<v-spacer></v-spacer>
				<v-dialog v-model="dialog" max-width="500px">
					<template v-slot:activator="{ on, attrs }">
						<v-btn color="primary" dark v-bind="attrs" v-on="on">
							Добавить менеджера
						</v-btn>
					</template>
					<v-card>
						<v-card-title>
							<span class="text-h5"
								>Добавить менеджера ресторана</span
							>
						</v-card-title>

						<v-card-text>
							<v-container>
								<v-text-field
									v-model="editedItem.name"
									label="Имя"
								></v-text-field>
								<v-text-field
									v-model="editedItem.email"
									label="E-mail"
								></v-text-field>
								<v-text-field
									v-model="editedItem.password"
									label="Пароль"
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
			</v-toolbar>
		</template>
	</v-data-table>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class Users extends Vue {
	headers = [
		{
			text: 'Имя',
			align: 'start',
			sortable: false,
			value: 'name',
		},
		{
			text: 'E-mail',
			align: 'start',
			sortable: false,
			value: 'email',
		},
		{
			text: 'Роль',
			align: 'start',
			sortable: false,
			value: 'role',
		},
	]
	users: [] = []
	editedIndex = -1
	editedItem = {
		name: '',
		email: '',
		password: '',
	}
	defaultItem = {
		name: '',
		email: '',
		password: '',
	}
	dialog = false
	async mounted(): Promise<void> {
		this.users = (await this.$axios.post('/api/admin/users')).data
	}
	editItem(item: any) {
		this.editedIndex = this.users.indexOf(item)
		this.editedItem = Object.assign({}, item)
		this.dialog = true
	}

	close() {
		this.dialog = false
		this.$nextTick(() => {
			this.editedItem = Object.assign({}, this.defaultItem)
			this.editedIndex = -1
		})
	}

	save() {
		this.$axios
			.post('/api/admin/createManger', this.editedItem)
			.then((response) => {
				this.users.push(this.editedItem)
			})
			.catch((error) => {
				console.error(error)
				console.error(error.response)
			})
		this.close()
	}
}
</script>

<style></style>
