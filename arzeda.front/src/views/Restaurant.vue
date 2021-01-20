<template>
    <div>
        <div class="d-flex">
            <div style="flex: 1 1 auto">
                <h1>Название ресторана</h1>
                <v-chip-group>
                  <v-chip class="ma-2">30 мин</v-chip>
                  <v-chip class="ma-2">От 1 ₽</v-chip>
                  <v-menu offset-y>
                    <template v-slot:activator="{ on, attrs }">
                        <v-chip class="ma-2" v-bind="attrs"
                        v-on="on">i</v-chip>
                    </template>
                    <v-card class="pa-2 grey--text">
                        <h3 class="black--text">Название ресторана</h3>
                        <p>
                            <span>Велозаводская улица, 13с1</span> &middot; <span>Доставка до 21:30</span>
                        </p>
                        <p>
                            <span>Бургеры</span> &middot; <span>Фастфуд</span>
                        </p>
                        <p>Юридическая инфа</p>
                    </v-card>
                </v-menu>
                </v-chip-group>
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
            <v-chip-group active-class="blue white--text" class="white ml-n1" style="position: sticky; top: 64px; z-index: 2" nav>
                <v-chip link to="#popular" class="ma-2">Популярное</v-chip>
                <v-chip link to="#breakfasts" class="ma-2">Завтраки</v-chip>
                <v-chip link to="#salads" class="ma-2">Салаты</v-chip>
                <v-chip link to="#drinks" class="ma-2">Напитки</v-chip>
                <v-chip link to="#desserts" class="ma-2">Десерты</v-chip>
                <v-chip link to="#maindishes" class="ma-2">Основные блюда</v-chip>
            </v-chip-group>
        <!--<v-chip-group active-class="blue white--text">
            <router-link :to="{ path: '/restaurant', hash: '#popular' }"><v-chip class="ma-2">Популярное</v-chip></router-link>
            <router-link :to="{ path: '/restaurant', hash: '#breakfasts' }"><v-chip class="ma-2">Завтраки</v-chip></router-link>
            <v-chip class="ma-2">Салаты</v-chip>
            <v-chip class="ma-2">Основные блюда</v-chip>
            <v-chip class="ma-2">Десерты</v-chip>
            <v-chip class="ma-2">Напитки</v-chip>
        </v-chip-group>-->
        <div>
            <div id="popular">
                <h3 class="mb-2">Популярное</h3>
                <div class="grid-container">
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
                    </v-card-actions>
                    </v-card>
                </div>
            </div>
            <v-divider class="mt-5 mb-3"></v-divider>
            <div id="breakfasts">
                <h3 class="mb-2">Завтраки</h3>
                <div class="grid-container">
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
                    </v-card-actions>
                    </v-card>
                </div>
            </div>
            <v-divider class="mt-5 mb-3"></v-divider>
            <div id="salads">
                <h3 class="mb-2">Салаты</h3>
                <div class="grid-container">
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
                    </v-card-actions>
                    </v-card>
                </div>
            </div>
            <v-divider class="mt-5 mb-3"></v-divider>
            <div id="maindishes">
                <h3 class="mb-2">Основные блюда</h3>
                <div class="grid-container">
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
                    </v-card-actions>
                    </v-card>
                </div>
            </div>
            <v-divider class="mt-5 mb-3"></v-divider>
            <div id="desserts">
                <h3 class="mb-2">Десерты</h3>
                <div class="grid-container">
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
                    </v-card-actions>
                    </v-card>
                </div>
            </div>
            <v-divider class="mt-5 mb-3"></v-divider>
            <div id="drinks">
                <h3 class="mb-2">Напитки</h3>
                <div class="grid-container">
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
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
                    <v-card-text>
                        вглкарпщшрвпопваоповлдоаплоавлпвл влдпрвлдпо шларв дллдваповлдодлвашплд ы  вкшпр дывлапрд
                    </v-card-text>

                    <v-card-actions class="justify-space-between">
                            <div>250 P</div>
                            <v-btn
                                color="blue"
                                class="white--text"
                            >
                                Button
                            </v-btn>
                    </v-card-actions>
                    </v-card>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Restaurant extends Vue {}
</script>

<style lang="scss" scoped>
.grid-container {
  display: grid;
    grid-gap: 1rem;
    grid-template-columns: repeat(auto-fit, 344px);
}
</style>