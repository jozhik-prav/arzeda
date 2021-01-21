<template>
    <v-tabs vertical>
      <v-tab>
        <v-icon left>
          mdi-account
        </v-icon>
        Профиль
      </v-tab>
      <v-tab>
        <v-icon left>
          mdi-cart-outline
        </v-icon>
        Заказы
      </v-tab>

      <v-tab-item>
        <v-card flat>
          <v-form>
            <v-text-field
                label="Имя"
            ></v-text-field>
            <v-text-field
                label="Номер телефона"
            ></v-text-field>
            <v-text-field
                label="Адрес"
            ></v-text-field>
            <v-row>
                <v-col>
                    <v-text-field
                        label="Подъезд"
                    ></v-text-field>
                </v-col>
                <v-col>
                    <v-text-field
                        label="Домофон"
                    ></v-text-field>
                </v-col>
                <v-col>
                    <v-text-field
                        label="Этаж"
                    ></v-text-field>
                </v-col>
                <v-col>
                    <v-text-field
                        label="Квартира"
                    ></v-text-field>
                </v-col>
            </v-row>
            <v-btn color="blue" class="white--text">Сохранить</v-btn>
          </v-form>
        </v-card>
      </v-tab-item>
      <v-tab-item>
        <v-card outlined class="pa-3 mb-5">
          <div class="d-flex">
            <div style="flex: 1 1 auto">
                <h3 class="mb-5">Название ресторана</h3>
                <p class="mb-1">21 января 2021, 19:15</p>
                <p>Россия, Москва, Москворецкая набержна, 19</p>
            </div>
            <div style="flex: 0 0 auto">
                <v-img
                    src="https://picsum.photos/id/11/500/300"
                    aspect-ratio="1"
                    class="grey lighten-2"
                    width="126px"
                ></v-img>
            </div>
        </div>
        <v-divider class="mt-5 mb-3"></v-divider>
        <v-row>
            <v-col>Название блюда</v-col>
            <v-col cols="1" class="text-right">1 шт</v-col>
            <v-col cols="1" class="text-right">537 ₽</v-col>
        </v-row>
        <v-row>
            <v-col>Название блюда</v-col>
            <v-col cols="1" class="text-right">1 шт</v-col>
            <v-col cols="1" class="text-right">537 ₽</v-col>
        </v-row>
        <v-row class="mt-3 mb-3">
            <v-col>Доставка</v-col>
            <v-col cols="1" class="text-right">Бесплатно</v-col>
        </v-row>
        <v-row class="text-h6">
            <v-col >Итого</v-col>
            <v-col cols="1" class="text-right">537 ₽</v-col>
        </v-row>
        </v-card>
        <v-card outlined class="pa-3 mb-5">
          <div class="d-flex">
            <div style="flex: 1 1 auto">
                <h3 class="mb-5">Название ресторана</h3>
                <p class="mb-1">21 января 2021, 19:15</p>
                <p>Россия, Москва, Москворецкая набержна, 19</p>
            </div>
            <div style="flex: 0 0 auto">
                <v-img
                    src="https://picsum.photos/id/11/500/300"
                    aspect-ratio="1"
                    class="grey lighten-2"
                    width="126px"
                ></v-img>
            </div>
        </div>
        <v-divider class="mt-5 mb-3"></v-divider>
        <v-row>
            <v-col>Название блюда</v-col>
            <v-col cols="1" class="text-right">1 шт</v-col>
            <v-col cols="1" class="text-right">537 ₽</v-col>
        </v-row>
        <v-row>
            <v-col>Название блюда</v-col>
            <v-col cols="1" class="text-right">1 шт</v-col>
            <v-col cols="1" class="text-right">537 ₽</v-col>
        </v-row>
        <v-row class="mt-3 mb-3">
            <v-col>Доставка</v-col>
            <v-col cols="1" class="text-right">Бесплатно</v-col>
        </v-row>
        <v-row class="text-h6">
            <v-col >Итого</v-col>
            <v-col cols="1" class="text-right">537 ₽</v-col>
        </v-row>
        </v-card>
      </v-tab-item>
    </v-tabs>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src

@Component({
  components: {
   // HelloWorld
  }
})
export default class Account extends Vue {}
</script>