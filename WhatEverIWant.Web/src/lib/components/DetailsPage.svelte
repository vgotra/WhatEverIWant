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
</script>

{#if $item}
	<div class="bg-white p-4 rounded shadow">
		<h2 class="text-lg font-bold">{$item.name}</h2>
		<p>{$item.description}</p>
		<a href={`/edit/${$item.id}`} class="text-blue-500">Edit</a>
		<button
			class="text-red-500"
			on:click={async () => {
				await fetch(`${apiEndpoint}/${id}`, { method: 'DELETE' });
				window.location.href = '/';
			}}>Delete</button
		>
	</div>
{/if}
