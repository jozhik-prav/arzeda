<template>
<div>
        <h2 class="mb-2">Рестораны</h2>
        <v-text-field
            outlined
            label="Название, кухня или блюдо..."
            prepend-inner-icon="mdi-magnify"
          ></v-text-field>
          <v-chip-group active-class="blue white--text">
            <v-chip class="ma-2">Все</v-chip>
            <v-chip class="ma-2">Бургеры</v-chip>
            <v-chip class="ma-2">Суши</v-chip>
            <v-chip class="ma-2">Пицца</v-chip>
            <v-chip class="ma-2">Десерты</v-chip>
            <v-chip class="ma-2">Шашлыки</v-chip>
            <v-chip class="ma-2">Здоровая еда</v-chip>
            <v-chip class="ma-2">Мясо и рыба</v-chip>
          </v-chip-group>
          <div class="grid-container">
            <router-link to="/restaurant"><v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card></router-link>
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
            
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
            
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
            
            <v-card
              class="mx-auto"
              max-width="344"
            >
              <v-img
                src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
                height="160px"
              ></v-img>

              <v-card-title>
                Top western road trips
              </v-card-title>

              <v-card-actions>
                <v-chip-group active-class="blue white--text">
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                </v-chip-group>
              </v-card-actions>
            </v-card>
          </div>
          </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src

@Component({
  components: {
   // HelloWorld
  }
})
export default class Home extends Vue {}
</script>

<style lang="scss" scoped>
.grid-container {
  display: grid;
    grid-gap: 1rem;
    grid-template-columns: repeat(auto-fit, 344px);
}
</style>