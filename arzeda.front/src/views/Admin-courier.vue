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
						:disabled="!isEditing"
					></v-text-field>
					<v-text-field
						label="E-mail"
						value=""
						:disabled="!isEditing"
					></v-text-field>
					<v-text-field
						label="Phone"
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
		</v-tabs>
	</v-card>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class AdminCourier extends Vue {
	isEditing = false
	headersOrders = [
		{
			text: 'Number',
			align: 'start',
			value: 'number',
			filter: () => {
				return 1
			},
		},
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
			text: 'Status',
			align: 'start',
			value: 'status',
			filter: () => {
				return 1
			},
		},
	]
	orders: [] = []
}
</script>
