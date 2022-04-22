<template>
	<v-card class="mx-auto" width="30%">
		<v-card-title primary-title>
			<h3 class="headline mb-0">Зарегистрироваться</h3>
		</v-card-title>
		<v-card-text>
			<v-form ref="form" v-model="valid">
				<v-text-field
					v-model="email"
					label="E-mail"
					:rules="emailRules"
					required
				></v-text-field>
				<v-text-field
					v-model="password"
					required
					:rules="passwordRules"
					:append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
					:type="show ? 'text' : 'password'"
					name="password"
					label="Password"
					@click:append="show = !show"
				></v-text-field>
				<v-btn
					:disabled="!valid"
					color="primary"
					class="mx-auto d-block"
					@click="register"
				>
					Зарегистрироваться
				</v-btn>
				<router-link to="/login" class="text-decoration-none">
					<v-btn text color="primary" class="mx-auto d-block">
						Вернуться на страницу входа
					</v-btn>
				</router-link>
			</v-form>
		</v-card-text>
	</v-card>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
	components: {},
})
export default class Registration extends Vue {
	valid = false
	email = ''
	emailRules = [(v: string) => !!v || 'E-mail обязателен']
	password = ''
	passwordRules = [
		(v: string) => !!v || 'Пароль обязателен',
		(v: string) =>
			(v && v.length >= 6) || 'В пароле должно быть больше 5 знаков',
		(v: string) =>
			/\d/.test(v) || 'В пароле должна быть хотя бы одна цифра',
		(v: string) =>
			/[A-Z]/.test(v) ||
			'В пароле должна быть хотя бы одна заглавная буква',
		(v: string) =>
			/[!@#$%^&*(),.?":{}|<>]/.test(v) ||
			'В пароле должен быть хотя бы один символ',
	]
	show = false
	register() {
		this.$axios
			.post('/api/account/register', {
				email: this.email,
				password: this.password,
			})
			.then(() => {
				this.$router.push('/')
			})
			.catch(e => {
				console.log(e)
			})
	}
}
</script>
