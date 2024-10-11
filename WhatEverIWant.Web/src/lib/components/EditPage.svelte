<script lang="ts">
	import { onMount } from 'svelte';
	import { writable } from 'svelte/store';

	export let apiEndpoint: string;
	export let id: string;

	const item = writable<{ name: string; description: string; id: string } | null>(null);

	onMount(async () => {
		const response = await fetch(`${apiEndpoint}/${id}`);
		const data = await response.json();
		item.set(data);
	});

	async function save() {
		await fetch(`${apiEndpoint}/${id}`, {
			method: 'PUT',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify($item)
		});
		window.location.href = `/details/${id}`;
	}
</script>

{#if $item}
	<div class="bg-white p-4 rounded shadow">
		<input type="text" bind:value={$item.name} class="block w-full mb-2 p-2 border rounded" />
		<textarea bind:value={$item.description} class="block w-full mb-2 p-2 border rounded"
		></textarea>
		<button class="text-blue-500" on:click={save}>Save</button>
	</div>
{/if}
