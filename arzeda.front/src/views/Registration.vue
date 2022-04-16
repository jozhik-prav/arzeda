<template>
	<v-card class="mx-auto" width="30%">
		<v-card-title primary-title>
			<h3 class="headline mb-0">Зарегистрироваться</h3>
		</v-card-title>
		<v-card-text>
			<v-form ref="form" v-model="valid" lazy-validation>
				<v-text-field
					v-model="name"
					:counter="10"
					:rules="nameRules"
					label="Name"
					required
				></v-text-field>
				<v-text-field
					v-model="email"
					:rules="emailRules"
					label="E-mail"
					required
				></v-text-field>
				<v-text-field
					v-model="password"
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
	valid = true
	name = ''
	nameRules = [
		(v: any) => !!v || 'Name is required',
		(v: any) =>
			(v && v.length <= 10) || 'Name must be less than 10 characters',
	]
	email = ''
	emailRules = [
		(v: any) => !!v || 'E-mail is required',
		(v: any) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
	]
	show = false
	validate() {
		this.$refs.form.validate()
	}
}
</script>
