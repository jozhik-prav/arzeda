<template>
    <div class="item d-flex align-center pt-2 pb-2">
        <v-img
            src="https://picsum.photos/id/11/500/300"
            aspect-ratio="1"
            class="flex-grow-0 flex-shrink-0 mr-2"
            width="100px"
        ></v-img>
        <main class="item-content">
            <h3 class="blue--text">Название еды</h3>
            <p>Описание</p>
        </main>
        <div class="item-control">
            <button class="control-btn">-</button>
            <span> 1 </span>
            <button class="control-btn">+</button>
        </div>
        <div class="item-price">
            <p class="price">350 ₽</p>
        </div>
        <a class="item-delete"><v-icon left>
            mdi-close
            </v-icon>
        </a>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class OrderLine extends Vue {}
</script>


<style lang="scss" scoped>
.item {
    border-bottom: 1px solid #cccbcb;
    @media screen and (max-width: 480px) {
        flex-wrap: wrap;
        justify-content: center;
    }
}

.item-content {
    display: flex;
    flex: 1 1 auto;
    flex-flow: column;
    justify-content: center;
    h5 {
    }
    @media screen and (max-width: 480px) {
        flex: 1 1 70%;
        margin-bottom: 20px;
    }
}

.item-control {
    flex: 0 0 auto;
    display: flex;
    align-items: center;
    border: 1px solid #1976d2;
    border-radius: 5px;
    .control-btn {
        background: transparent;
        color: #fff;
        padding: 0 20px;
        border: none;
        outline: none;
        font-size: 24px;
        cursor: pointer;

        &:hover {
            color: #d94f2b;
        }
    }
}

.item-price {
    flex: 0 0 auto;
    display: flex;
    flex-flow: column;
    justify-content: center;
    padding: 0 10px;
    margin: 0 12px;
    text-align: center;
    .price {
        color: #1976d2;
        font-size: 24px;
        margin-bottom: 0;
    }
}

.discount {
    .price {
        color: #fff;
        text-decoration: line-through;
        font-size: 14px;
        margin-top: -17px;
        @media screen and (max-width: 480px) {
            margin-top: 0;
            margin-right: 10px;
        }
    }

    .new-price {
        color: #d94f2b;
        font-size: 24px;
    }

    @media screen and (max-width: 480px) {
        display: flex;
        flex-flow: row;
        align-items: center;
    }
}

.item-delete {
    display: flex;
    flex-flow: column;
    justify-content: center;
    img {
        width: 20px;
    }
}
</style>