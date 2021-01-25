<template>
	<v-app>
		<Header></Header>
		<v-main>
			<v-container>
				<router-view />
			</v-container>
		</v-main>
	</v-app>
</template>

<script lang="ts">
import Vue from 'vue'
import Header from './components/Header.vue'

export default Vue.extend({
	name: 'App',

	components: {
		Header,
	},

	data: () => ({
		//
	}),
})
</script>
