Claro! Aqui está o código Vue.js correspondente ao seu Controller:

```vue
<template>
    <div>
        <h1>List of Knights</h1>
        <button @click="getKnights()">Get Knights</button>
        <ul v-if="knights.length">
            <li v-for="knight in knights" :key="knight._id">
                {{ knight.name }} - {{ knight.nickname }} - {{ knight.birthday }}
                <button @click="deleteKnight(knight._id)">Delete</button>
            </li>
        </ul>
        <button @click="createKnight()">Create Knight</button>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                knights: []
            };
        },
        methods: {
            async getKnights() {
                try {
                    const response = await fetch("/Knights");
                    this.knights = await response.json();
                } catch (error) {
                    console.error(error);
                }
            },
            async createKnight() {
                try {
                    const response = await fetch("/Knights", {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify({
                            name: "New Knight",
                            nickname: "New Nickname",
                            birthday: "2000-01-01"
                        })
                    });
                    const newKnight = await response.json();
                    this.knights.push(newKnight);
                } catch (error) {
                    console.error(error);
                }
            },
            async deleteKnight(id) {
                try {
                    await fetch(`/Knights/${id}`, {
                        method: "DELETE"
                    });
                    this.knights = this.knights.filter(knight => knight._id !== id);
                } catch (error) {
                    console.error(error);
                }
            }
        }
    };
</script>

<style scoped>
    /* Add your custom styles here */
</style>

<!--<template>
    <WelcomeItem>
        <template #icon>
            <DocumentationIcon />
        </template>
        <template #heading>
            Documentation
        </template>

        <p>O desafio Knights visa a construcao de um sistema de cadastro de herois utilizando as seguintes tecnologias:</p>
        <ul>
            <li>Vue.js</li>
            <li>C# (.NET 7+)</li>
            <li>MongoDB</li>
            <li>Servicos em containers (script para build e geracao)</li>
        </ul>

    </WelcomeItem>

    <div>
        <h1>Lista de Cavaleiros</h1>
        <button @click="fetchKnights">Busca de Cavaleiros</button>
        <ul>
            <li v-for="knight in knights" :key="knight._id">
                {{ knight.name }} - {{ knight.isHero ? 'Hero' : 'Not a Hero' }}
            </li>
        </ul>
    </div>

</template>-->
