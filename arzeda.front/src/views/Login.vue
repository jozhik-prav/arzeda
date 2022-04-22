<template>
	<v-card class="mx-auto" width="30%">
		<v-card-title primary-title>
			<h3 class="headline mb-0">Войти</h3>
		</v-card-title>
		<v-card-text>
			<v-form ref="form" v-model="valid">
				<v-text-field
					v-model="email"
					:rules="emailRules"
					label="E-mail"
					required
				></v-text-field>
				<v-text-field
					v-model="password"
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
					class="mr-4"
					@click="login"
				>
					Войти
				</v-btn>
				<router-link to="/registration" class="text-decoration-none">
					<v-btn text color="primary">
						Зарегистрироваться
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
export default class Login extends Vue {
	valid = true
	email = ''
	emailRules = [(v: any) => !!v || 'E-mail обязателен']
	password = ''
	passwordRules = [(v: any) => !!v || 'Пароль обязателен']
	show = false

	login() {
		this.$axios
			.post('/api/account/login', {
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
