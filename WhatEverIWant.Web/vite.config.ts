import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vite';

export default defineConfig({
	plugins: [sveltekit()],
	server: {
		port: 7000,
		// Additional server options:
		// host: '0.0.0.0', // For external access
		// strictPort: true, // If true, Vite will exit if the port is in use
	  }
});
