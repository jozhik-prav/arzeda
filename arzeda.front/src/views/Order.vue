<template>
	<v-stepper v-model="e1">
		<v-stepper-header>
			<v-stepper-step :complete="e1 > 1" step="1">
				Шаг 1
			</v-stepper-step>

			<v-divider></v-divider>

			<v-stepper-step :complete="e1 > 2" step="2">
				Шаг 2
			</v-stepper-step>
		</v-stepper-header>

		<v-stepper-items>
			<v-stepper-content step="1">
				<v-card class="mb-12" tile flat>
					<OrderLine
						v-for="item in this.$store.state.order"
						:key="item.index"
						:orderLine="item"
					></OrderLine>
					<div class="d-flex justify-space-between align-center">
						<div class="font-weight-bold text-h6">
							Сумма заказа:
						</div>
						<div class="blue--text font-weight-bold text-h4">
							{{ this.$store.getters.totalSum }} ₽
						</div>
					</div>
				</v-card>

				<v-btn color="primary" @click="e1 = 2">
					Продолжить
				</v-btn>

				<v-btn text>
					Вернуться к меню
				</v-btn>
			</v-stepper-content>

			<v-stepper-content step="2">
				<v-card class="mb-12">
					<v-form>
						<v-text-field
							label="Адрес"
							v-model="address"
						></v-text-field>
						<v-row>
							<v-col>
								<v-text-field
									label="Подъезд"
									v-model="entrance"
								></v-text-field>
							</v-col>
							<v-col>
								<v-text-field
									label="Домофон"
									v-model="intercom"
								></v-text-field>
							</v-col>
							<v-col>
								<v-text-field
									label="Этаж"
									v-model="floor"
								></v-text-field>
							</v-col>
							<v-col>
								<v-text-field
									label="Квартира"
									v-model="flat"
								></v-text-field>
							</v-col>
						</v-row>
						<v-textarea
							label="Комментарий"
							v-model="comment"
						></v-textarea>
					</v-form>
				</v-card>

				<v-btn color="primary" @click="send()">
					Заказать
				</v-btn>

				<v-btn text @click="e1 = 1">
					Отмена
				</v-btn>
			</v-stepper-content>
		</v-stepper-items>
	</v-stepper>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import OrderLine from '@/components/OrderLine.vue'
import { OrderLine as OrderLineType } from '@/Types'

@Component({
	components: {
		OrderLine,
	},
})
export default class Order extends Vue {
	e1 = 1
	address = ''
	entrance = ''
	intercom = ''
	floor = 0
	flat = ''
	comment = ''

	async send() {
		const orderLinesState: OrderLineType[] = this.$store.state.order
		const orderLines = orderLinesState.map(x => ({
			productId: x.product.id,
			quantity: x.count,
			price: x.product.price,
		}))
		const order = {
			date: new Date().toISOString(),
			address: this.address,
			entrance: this.entrance,
			intercom: this.intercom,
			floor: this.floor,
			flat: this.flat,
			price: this.$store.getters.totalSum,
			comment: this.comment,
			restaurantId: orderLinesState[0].product.restaurantId,
			orderLines: orderLines,
		}
		try {
			const response = await this.$axios.post('/api/order', order)
			alert(`Спасибо за ваш заказ. Номер заказа: ${response.data}`)
		} catch (error) {
			alert(
				'Ваш заказ очень важен для нас. В данный момент все менеджеры заняты. Перезвоните позже'
			)
			console.error(error)
			console.error(error.response)
		}
	}
}
</script>
