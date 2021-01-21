<template>
  <v-stepper v-model="e1">
    <v-stepper-header>
      <v-stepper-step
        :complete="e1 > 1"
        step="1"
      >
        Шаг 1
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step
        :complete="e1 > 2"
        step="2"
      >
        Шаг 2
      </v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>
      <v-stepper-content step="1">
        <v-card
          class="mb-12"
          tile
          flat
        >
            <OrderLine></OrderLine>
            <div class="d-flex justify-space-between align-center">
                <div class="font-weight-bold text-h6">Сумма заказа:</div>
                <div class="blue--text font-weight-bold text-h4">350 ₽</div>
            </div>
        </v-card>

        <v-btn
          color="primary"
          @click="e1 = 2"
        >
          Продолжить
        </v-btn>

        <v-btn text>
          Вернуться к меню
        </v-btn>
      </v-stepper-content>

      <v-stepper-content step="2">
        <v-card
          class="mb-12"
        >
            <v-form>
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
                <v-textarea
                label="Комментарий"
                ></v-textarea>
            </v-form>
        </v-card>

        <v-btn
          color="primary"
        >
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
import { Component, Vue } from "vue-property-decorator";
import OrderLine from "@/components/OrderLine.vue";

@Component({
  components: {
    OrderLine
  }
})
export default class Order extends Vue {
    e1 = 1
}
</script>
