export default {
    data() {
        return {
            knights: [],
        };
    },
    methods: {
        async fetchKnights() {
            try {
                const response = await fetch('/knights'); // Replace with your API endpoint
                const data = await response.json();
                this.knights = data;
            } catch (error) {
                console.error('Error fetching knights:', error);
            }
        },
    },
}; 