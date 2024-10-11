<script lang="ts">
	import { onMount } from 'svelte';
	import { writable } from 'svelte/store';

	export let apiEndpoint: string;
	export let itemComponent: { name: string; description: string; id: string };

	const items = writable([]);

	onMount(async () => {
		const response = await fetch(apiEndpoint);
		const data = await response.json();
		items.set(data);
	});
</script>

<div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
	{#each $items as item}
		<svelte:component this={itemComponent} {item} />
	{/each}
</div>
