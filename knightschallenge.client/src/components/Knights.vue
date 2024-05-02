<script setup>import WelcomeItem from './WelcomeItem.vue'
import DocumentationIcon from './icons/IconDocumentation.vue'
import ToolingIcon from './icons/IconTooling.vue'
import EcosystemIcon from './icons/IconEcosystem.vue'
import CommunityIcon from './icons/IconCommunity.vue'
import SupportIcon from './icons/IconSupport.vue'</script>

<template>
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

    <!--<WelcomeItem>
        <template #icon>
            <ToolingIcon />
        </template>
        <template #heading>
            Tooling
        </template>

        This project is served and bundled with
        <a href="https://vitejs.dev/guide/features.html" target="_blank" rel="noopener">Vite</a>. The
        recommended IDE setup is
        <a href="https://code.visualstudio.com/" target="_blank" rel="noopener">VSCode</a> +
        <a href="https://github.com/johnsoncodehk/volar" target="_blank" rel="noopener">Volar</a>. If
        you need to test your components and web pages, check out
        <a href="https://www.cypress.io/" target="_blank" rel="noopener">Cypress</a> and
        <a href="https://on.cypress.io/component" target="_blank" rel="noopener">Cypress Component Testing</a>.

        <br />

        More instructions are available in <code>README.md</code>.
    </WelcomeItem>-->

    <!--<WelcomeItem>
        <template #icon>
            <EcosystemIcon />
        </template>
        <template #heading>
            Ecosystem
        </template>

        Get official tools and libraries for your project:
        <a href="https://pinia.vuejs.org/" target="_blank" rel="noopener">Pinia</a>,
        <a href="https://router.vuejs.org/" target="_blank" rel="noopener">Vue Router</a>,
        <a href="https://test-utils.vuejs.org/" target="_blank" rel="noopener">Vue Test Utils</a>, and
        <a href="https://github.com/vuejs/devtools" target="_blank" rel="noopener">Vue Dev Tools</a>. If
        you need more resources, we suggest paying
        <a href="https://github.com/vuejs/awesome-vue" target="_blank" rel="noopener">Awesome Vue</a>
        a visit.
    </WelcomeItem>-->

        <template>
            <div>
                <h1>Knights List</h1>
                <button @click="fetchKnights">Fetch Knights</button>
                <ul>
                    <li v-for="knight in knights" :key="knight._id">
                        {{ knight.name }} - {{ knight.isHero ? 'Hero' : 'Not a Hero' }}
                    </li>
                </ul>
            </div>
        </template>       

    <WelcomeItem>
        <template #icon>
            <CommunityIcon />
        </template>
        <template #heading>
            Community
        </template>

        Got stuck? Ask your question on
        <a href="https://chat.vuejs.org" target="_blank" rel="noopener">Vue Land</a>, our official
        Discord server, or
        <a href="https://stackoverflow.com/questions/tagged/vue.js" target="_blank" rel="noopener">StackOverflow</a>. You should also subscribe to
        <a href="https://news.vuejs.org" target="_blank" rel="noopener">our mailing list</a> and follow
        the official
        <a href="https://twitter.com/vuejs" target="_blank" rel="noopener">@vuejs</a>
        twitter account for latest news in the Vue world.
    </WelcomeItem>    
</template>
