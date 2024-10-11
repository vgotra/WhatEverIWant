<script lang="ts">
	import Topbar from '$lib/components/Topbar.svelte';
	import Sidebar from '$lib/components/Sidebar.svelte';
	import MainContent from '$lib/components/MainContent.svelte';

	const sidebarItems = [
		{ name: 'AudioBooks', link: '/audiobooks' },
		{ name: 'Books', link: '/books' },
		{ name: 'Movies', link: '/movies' },
		{ name: 'Music', link: '/music' },
		{ name: 'Series', link: '/series' }
	];
</script>

<svelte:head>
	<title>What Ever I Want</title>
</svelte:head>

<div class="flex flex-col min-h-screen">
	<Topbar title="What Ever I Want" />
	<div class="flex flex-row flex-grow mt-16">
		<Sidebar items={sidebarItems} />
		<MainContent class="flex-grow">
			<slot></slot>
		</MainContent>
	</div>
</div>
